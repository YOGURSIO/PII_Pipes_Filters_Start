using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@".\beer.jpg");

            IFilter fn = new FilterNegative();  //filtros
            IFilter gs = new FilterGreyscale(); //filtros
            IFilter fs = new FilterSave();      //filtros

            IPipe pn = new PipeNull();
            
            IPipe ps = new PipeSerial(fn, pn);
            
            IPipe save1 = new PipeSerial(fs, pn);
            IPipe pf = new PipeFork(ps, save1);
            IPipe psi = new PipeSerial(gs, pf);

            IPicture image = psi.Send(picture);
            provider.SavePicture(image, @".\mmmcerveza.jpg");

        }
    }
}
