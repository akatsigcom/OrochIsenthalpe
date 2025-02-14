﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    int blocksPerLine;  
    int blocksPerColumn=2;
    public int shuffleLength = 20;
    public float defaultMoveDuration = .2f; // blocks' speed  
    public int nombrePermutation = 20;
    public float shuffleMoveDuration = .1f;

    public static Dictionary<string, Texture2D> dict; //dictionary of images for each letter
    public static string brailleWord; // word to find

    enum PuzzleState { Solved, Shuffling, InPlay }; //two possible states : solved or not
    PuzzleState state;

    Block emptyBlock; 
    Block[,] blocks; 
    Queue<Block> inputs;
    bool blockIsMoving; // no superposition of movements
    int shuffleMovesRemaining;
    Vector2Int prevShuffleOffset;

    string[] possibleBrailleWords = {"tresor" , "jekyll", "ecosse"} ;

    void Awake() {      // creation of the dictionary
        aBraille = Resources.Load("aBraille", typeof(Texture2D)) as Texture2D;
        bBraille = Resources.Load("bBraille", typeof(Texture2D)) as Texture2D;
        cBraille = Resources.Load("cBraille", typeof(Texture2D)) as Texture2D;
        dBraille = Resources.Load("dBraille", typeof(Texture2D)) as Texture2D;
        eBraille = Resources.Load("eBraille", typeof(Texture2D)) as Texture2D;
        fBraille = Resources.Load("fBraille", typeof(Texture2D)) as Texture2D;
        gBraille = Resources.Load("gBraille", typeof(Texture2D)) as Texture2D;
        hBraille = Resources.Load("hBraille", typeof(Texture2D)) as Texture2D;
        iBraille = Resources.Load("iBraille", typeof(Texture2D)) as Texture2D;
        jBraille = Resources.Load("jBraille", typeof(Texture2D)) as Texture2D;
        kBraille = Resources.Load("kBraille", typeof(Texture2D)) as Texture2D;
        lBraille = Resources.Load("lBraille", typeof(Texture2D)) as Texture2D;
        mBraille = Resources.Load("mBraille", typeof(Texture2D)) as Texture2D;
        nBraille = Resources.Load("nBraille", typeof(Texture2D)) as Texture2D;
        oBraille = Resources.Load("oBraille", typeof(Texture2D)) as Texture2D;
        pBraille = Resources.Load("pBraille", typeof(Texture2D)) as Texture2D;
        qBraille = Resources.Load("qBraille", typeof(Texture2D)) as Texture2D;
        rBraille = Resources.Load("rBraille", typeof(Texture2D)) as Texture2D;
        sBraille = Resources.Load("sBraille", typeof(Texture2D)) as Texture2D;
        tBraille = Resources.Load("tBraille", typeof(Texture2D)) as Texture2D;
        uBraille = Resources.Load("uBraille", typeof(Texture2D)) as Texture2D;
        vBraille = Resources.Load("vBraille", typeof(Texture2D)) as Texture2D;
        wBraille = Resources.Load("wBraille", typeof(Texture2D)) as Texture2D;
        xBraille = Resources.Load("xBraille", typeof(Texture2D)) as Texture2D;
        yBraille = Resources.Load("yBraille", typeof(Texture2D)) as Texture2D;
        zBraille = Resources.Load("zBraille", typeof(Texture2D)) as Texture2D;
        _MajBraille = Resources.Load("_MajBraille", typeof(Texture2D)) as Texture2D;
        blankBraille = Resources.Load("blankBraille", typeof(Texture2D)) as Texture2D;

        dict = new Dictionary<string, Texture2D>
         {
         { "a",aBraille },
         { "b",bBraille },
         { "c",cBraille },
         { "d",dBraille },
         { "e",eBraille },
         { "f",fBraille },
         { "g",gBraille },
         { "h",hBraille },
         { "i",iBraille },
         { "j",jBraille },
         { "k",kBraille },
         { "l",lBraille },
         { "m",mBraille },
         { "n",nBraille },
         { "o",oBraille },
         { "p",pBraille },
         { "q",qBraille },
         { "r",rBraille },
         { "s",sBraille },
         { "t",tBraille },
         { "u",uBraille },
         { "v",vBraille },
         { "w",wBraille },
         { "x",xBraille },
         { "y",yBraille },
         { "z",zBraille },
         { "Maj",_MajBraille },
         {" ",blankBraille }

    };
    }


    void Start()
    {

        brailleWord = possibleBrailleWords[Random.Range(0, possibleBrailleWords.Length)]; // choose randomly a word
        blocksPerLine = brailleWord.Length + 2; // maj + blank case
        CreatePuzzle(); 
    }

    void Update()
    {
        if (state == PuzzleState.Solved && Input.GetKeyDown(KeyCode.Space))
        {
            StartShuffle();
        }
    }

    void CreatePuzzle()
    {
        
        blocks = new Block[blocksPerLine, blocksPerColumn];   // creation blocklist
        Texture2D[,] imageSlices = ImageSlicer.GetSlices(brailleWord, blocksPerLine);
        for (int y = 0; y < blocksPerColumn ; y++)
        {
            for (int x = 0; x < blocksPerLine; x++)
            {
                GameObject blockObject = GameObject.CreatePrimitive(PrimitiveType.Quad); // create block = Quad 
                blockObject.transform.position = new Vector2(-Vector2.one.x * (blocksPerLine - 1) * .5f + new Vector2(x, y).x, -Vector2.one.y * (blocksPerColumn - 1) * .5f + new Vector2(x, y).y); // symetrical to camera
                blockObject.transform.parent = transform;

                Block block = blockObject.AddComponent<Block>();
                block.OnBlockPressed += PlayerMoveBlockInput;
                block.OnFinishedMoving += OnBlockFinishedMoving;
                block.Init(new Vector2Int(x, y), imageSlices[x, y]);
                blocks[x, y] = block;

                blockObject.tag = letterAndPos(x, y); // apply a tag for each kind of letter and if it's top or bottom part 

                if (y == blocksPerColumn - 1 && x == blocksPerLine - 1)
                {
                    blockObject.SetActive(false); // disable block bottom right
                    emptyBlock = block;
                }

            }
        }

        for (int i = 0; i < nombrePermutation; i++) //shuffling
        {
            int a = Random.Range(0, blocksPerLine); // y
            int b = Random.Range(0, blocksPerColumn); // x

            int c = Random.Range(0, blocksPerLine);
            int d = Random.Range(0, blocksPerColumn);

            Vector2Int targetCoord = blocks[a, b].coord;
            blocks[a, b].coord = blocks[c, d].coord;
            blocks[c, d].coord = targetCoord;

            Vector2 targetPosition = blocks[a, b].transform.position;
            blocks[a, b].transform.position = blocks[c, d].transform.position;
            blocks[c, d].transform.position = targetPosition;
        }


        Camera.main.orthographicSize = Mathf.Max(blocksPerLine, blocksPerColumn) * .55f; // adapt camera to game
        inputs = new Queue<Block>();
        state = PuzzleState.InPlay;
    }

    string letterAndPos(int x, int y) // Find the right tag for each image
    {
        string letter;
        string pos;

        if (y == 0) { pos = "Bas"; }
        else { pos = "Haut";}

        if (x > 0 & x<=brailleWord.Length)
        {
            letter = brailleWord[x - 1].ToString();
        }
        else { letter = "Maj"; }

        if (x == brailleWord.Length + 1)
        {
            letter= "blank";
            pos="";
        }
        return letter + pos;
    }

    void PlayerMoveBlockInput(Block blockToMove)   
    {
        if (state == PuzzleState.InPlay)
        {
            inputs.Enqueue(blockToMove);
            MakeNextPlayerMove();
        }
    }

    void MakeNextPlayerMove()
    {
        while (inputs.Count > 0 && !blockIsMoving)
        {
            MoveBlock(inputs.Dequeue(), defaultMoveDuration);
        }
    }

    void MoveBlock(Block blockToMove, float duration)
    {
        if ((blockToMove.coord - emptyBlock.coord).sqrMagnitude == 1)
        {
            blocks[blockToMove.coord.x, blockToMove.coord.y] = emptyBlock;
            blocks[emptyBlock.coord.x, emptyBlock.coord.y] = blockToMove;

            Vector2Int targetCoord = emptyBlock.coord;
            emptyBlock.coord = blockToMove.coord;
            blockToMove.coord = targetCoord;

            Vector2 targetPosition = emptyBlock.transform.position;
            emptyBlock.transform.position = blockToMove.transform.position;
            blockToMove.MoveToPosition(targetPosition, duration);
            blockIsMoving = true;
        }
    }

    void OnBlockFinishedMoving()
    {
        blockIsMoving = false;
        CheckIfSolved();

        if (state == PuzzleState.InPlay)
        {
            MakeNextPlayerMove();
        }
        else if (state == PuzzleState.Shuffling)
        {
            if (shuffleMovesRemaining > 0)
            {
                MakeNextShuffleMove();
            }
            else
            {
                state = PuzzleState.InPlay;
            }
        }
    }

    void StartShuffle()
    {
        state = PuzzleState.Shuffling;
        shuffleMovesRemaining = shuffleLength;
        emptyBlock.gameObject.SetActive(false);
        MakeNextShuffleMove();
    }

    void MakeNextShuffleMove()
    {
        Vector2Int[] offsets = { new Vector2Int(1, 0), new Vector2Int(-1, 0), new Vector2Int(0, 1), new Vector2Int(0, -1) };
        int randomIndex = Random.Range(0, offsets.Length);

        for (int i = 0; i < offsets.Length; i++)
        {
            Vector2Int offset = offsets[(randomIndex + i) % offsets.Length];
            if (offset != prevShuffleOffset * -1)
            {
                Vector2Int moveBlockCoord = emptyBlock.coord + offset;

                if (moveBlockCoord.x >= 0 && moveBlockCoord.x < blocksPerColumn && moveBlockCoord.y >= 0 && moveBlockCoord.y < blocksPerLine)
                {
                    MoveBlock(blocks[moveBlockCoord.x, moveBlockCoord.y], shuffleMoveDuration);
                    shuffleMovesRemaining--;
                    prevShuffleOffset = offset;
                    break;
                }
            }
        }

    }

    public static bool currentWordOK;

    void CheckIfSolved() // Check if the images form in braille the right word
    {
        string[,] currentPos = new string[blocksPerLine,blocksPerColumn];
        int xpos;
        int ypos;
        string currentWord ="";
        bool maj = false;


        foreach (Block block in blocks)
        {
            xpos = block.coord.x;
            ypos = block.coord.y;
            currentPos[xpos, ypos] = block.tag;
        }
        if (currentPos[0, 0][0].ToString() == "M" & "M" == currentPos[0, 1][0].ToString())      //check first maj
        {
            if (currentPos[0, 0].Substring(currentPos[0, 0].Length - 3) == "Bas" & currentPos[0, 1].Substring(currentPos[0, 1].Length - 4) == "Haut")
            {
                maj = true;
            }
        }
        else
        {
            maj = false;
        }

        if (maj)        // check rest of letters
            {
            for (int x = 1; x < blocksPerLine; x++)
            {
                if (currentPos[x, 0][0].ToString() == currentPos[x, 1][0].ToString())
                {
                    if (currentPos[x, 0].Substring(currentPos[x, 0].Length - 3) == "Bas" & currentPos[x, 1].Substring(currentPos[x, 1].Length - 4) == "Haut")
                    {
                        currentWord += currentPos[x, 0][0].ToString();
                    }
                }
                else
                {
                    currentWord += " ";
                }
            }
        }
        if (currentWord == brailleWord)
        {
            state = PuzzleState.Solved;
            emptyBlock.gameObject.SetActive(true);
            currentWordOK = true;
        }
        else
        {
            currentWordOK = false;
        }
        Debug.Log(currentWord);
    }

    public static Texture2D aBraille;
    static Texture2D bBraille;
    static Texture2D cBraille;
    static Texture2D dBraille;
    static Texture2D eBraille;
    static Texture2D fBraille;
    static Texture2D gBraille;
    static Texture2D hBraille;
    static Texture2D iBraille;
    static Texture2D jBraille;
    static Texture2D kBraille;
    static Texture2D lBraille;
    static Texture2D mBraille;
    static Texture2D nBraille;
    static Texture2D oBraille;
    static Texture2D pBraille;
    static Texture2D qBraille;
    static Texture2D rBraille;
    static Texture2D sBraille;
    static Texture2D tBraille;
    static Texture2D uBraille;
    static Texture2D vBraille;
    static Texture2D wBraille;
    static Texture2D xBraille;
    static Texture2D yBraille;
    static Texture2D zBraille;
    static Texture2D _MajBraille;
    static Texture2D blankBraille;


}
