using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // Ejercicio 1
            
            PictureProvider provider = new PictureProvider();
            IPicture beer = provider.GetPicture(@"beer.jpg");
            
            FilterSave filterSave = new FilterSave();
            FilterGreyscale filterGrey = new FilterGreyscale();
            FilterNegative filterNegative = new FilterNegative();

            PipeNull pipeNull = new PipeNull();
            
            PipeSerial pipeSerialG = new PipeSerial(filterGrey, pipeNull);
            PipeSerial pipeSerialN = new PipeSerial(filterNegative, pipeSerialG);
            PipeSerial pipeSerialS = new PipeSerial(filterSave, pipeSerialN);

            beer = pipeSerialG.Send(beer);

            // Ejercicio 2
            
            provider.SavePicture(beer, @"beerFiltered.jpg");

            
        }
    }
}
