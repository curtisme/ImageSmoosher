using System;
using System.Drawing;

public class ImageSmoosher
{
    public static void Main(string[] args)
    {
        if (args.Length < 3)
        {
            Console.WriteLine("Inocrrect usage!");
            return;
        }

        Bitmap im1,im2,newIm,tmp;
        Random rng;

        try
        {
            im1 = new Bitmap(args[0]);
            im2 = new Bitmap(args[1]);

            rng = new Random();

            if (im1.Height != im2.Height ||
                    im1.Width != im2.Width)
            {
                Console.WriteLine("Image dimensions do not match!");
                Console.WriteLine("Image 1 is {0} x {1}",
                        im1.Width, im1.Height);
                Console.WriteLine("Image 2 is {0} x {1}",
                        im2.Width, im2.Height);
            }

            else
            {
                newIm = new Bitmap(im1.Width, im1.Height);
                for (int i=0;i<newIm.Width;i++)
                {
                    for (int j=0;j<newIm.Height;j++)
                    {
                        tmp = rng.Next(2) < 1 ? im1 : im2;
                        newIm.SetPixel(i, j, tmp.GetPixel(i, j));
                    }
                }
                newIm.Save(args[2]);
            }
        }

        catch (Exception e)
        {
            Console.Error.WriteLine(e);
        }
    }
}
