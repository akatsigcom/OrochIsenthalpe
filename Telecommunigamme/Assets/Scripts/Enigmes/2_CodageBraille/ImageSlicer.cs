using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ImageSlicer
{

    public static Texture2D[,] GetSlices(string brailleWord, int blocksPerLine)
    {
        Texture2D image = Puzzle.dict["a"]; // to initiate the dimension one image is taken 
        int blockWidth = image.width;
        int blockHeight = image.height/2;
        Texture2D[,] blocks = new Texture2D[blocksPerLine, 2];

        image = Puzzle.dict["Maj"];  // No maj in the words to find so initiated manually
        for (int y = 0; y < 2; y++)
        {
            Texture2D block = new Texture2D(blockWidth, blockHeight);
            block.wrapMode = TextureWrapMode.Clamp;
            block.SetPixels(image.GetPixels(0 * blockWidth, y * blockHeight, blockWidth, blockHeight));     // cut the image in two 
            block.Apply();
            blocks[0, y] = block;
        }
   
        for (int x = 1; x < blocksPerLine - 1; x++) // each letter of the word is cut in half 
        {
            image = Puzzle.dict[brailleWord[x - 1].ToString()];
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
