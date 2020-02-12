//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace WCFServices.Pocos.Facades.Files.Compressors
//{
//    public class TypesComparision
//    {
//        private static TypesComparision _typecomparision;
//        private TypesComparision() { }
//        public static TypesComparision GetInstance()
//        {
//            if (_typecomparision == null)
//                _typecomparision = new TypesComparision();

//            return _typecomparision;

//        }

//        public ImageResizer.FitMode Convert(FitMode compressor)
//        {
//            switch (compressor)
//            {
//                case FitMode.Stretch:
//                    return ImageResizer.FitMode.Stretch;
//                case FitMode.Carve:
//                    return ImageResizer.FitMode.Carve;
//                case FitMode.Crop:
//                    return ImageResizer.FitMode.Crop;
//                case FitMode.Max:
//                    return ImageResizer.FitMode.Max;
//                case FitMode.None:
//                    return ImageResizer.FitMode.None;
//                case FitMode.Pad:
//                    return ImageResizer.FitMode.Pad;
                
//                default:
//                    return ImageResizer.FitMode.None;
                    
//            }

//        }
//    }
//}
