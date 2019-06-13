using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ImageSlicer
{

    public static Texture2D[,] GetSlices(string brailleWord, int blocksPerLine)
    {
        Texture2D image = Puzzle.dict["a"];
        //int blockSize = Mathf.Min(image.height / 2, image.width); // le Mathf.Min c'est pour éviter le probleme des images non parfaites géometriquement parlant
        int blockWidth = image.width;
        int blockHeight = image.height/2;


        Texture2D[,] blocks = new Texture2D[blocksPerLine, 2];

        image = Puzzle.dict["Maj"];
        for (int y = 0; y < 2; y++)
        {
            Texture2D block = new Texture2D(blockWidth, blockHeight);
            block.wrapMode = TextureWrapMode.Clamp;
            block.SetPixels(image.GetPixels(0 * blockWidth, y * blockHeight, blockWidth, blockHeight));
            block.Apply();
            blocks[0, y] = block;
        }

        for (int x = 1; x < blocksPerLine - 1; x++)
        {
            image = Puzzle.dict[brailleWord[x - 1].ToString()];
            Debug.Log(brailleWord[x - 1]);
            Debug.Log(image);
            for (int y = 0; y < 2; y++)
            {
                Texture2D block = new Texture2D(blockWidth, blockHeight);
                block.wrapMode = TextureWrapMode.Clamp;
                block.SetPixels(image.GetPixels(0, y*blockHeight , blockWidth, blockHeight));
                block.Apply();
                blocks[x, y] = block;
            }
        } 
        return blocks;

    }
}
