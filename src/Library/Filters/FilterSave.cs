using System;
using System.Drawing;

namespace CompAndDel.Filters
{
    /// <summary>
    /// Filtro que guarda una imagen sin modificarla.
    /// </remarks>
    public class FilterSave : IFilter
    {
        //Creo un contador para aplicarselo despues al PictureSave de PictureProvider
        //-----------------------------------------------------------------------------
        public static int contador = 0; 
        
        public static int Contador 
        {
            get
            {
                contador += 1;
                return contador;
            }
        }
        //-----------------------------------------------------------------------------
        /// Filtro que guarda una imagen sin modificarla.
        /// </summary>
        /// <param name="image">La imagen a guardar.</param>
        /// <returns>La imagen recibida.</returns>
        public IPicture Filter(IPicture image)
        {
            PictureProvider MidProvider = new PictureProvider();
            MidProvider.SavePicture(image, @".\fotocon" + Contador + "filtro.jpg" );
            return image;
        }
    }
}