using System;

namespace CompAndDel
{
    public class FilterSave : IFilter
    {
        protected int stepCounter;
        public IPicture Filter(IPicture image)
        {
            this.stepCounter = 0;
           
            string path = @$"..\Program\FilterSave\step{this.stepCounter}.jpg";
            PictureProvider provider = new PictureProvider();
            this.stepCounter += 1;
            provider.SavePicture(image, path);
            return image;

        }
    }
}
