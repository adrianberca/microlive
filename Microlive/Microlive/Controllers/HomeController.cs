using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace Microlive.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public object PerformCircleCount()
        {
            try
            {
                Image<Bgr, Byte> img = new Image<Bgr, byte>(@"D:\HckTM2016\Microlive second project\examples\ShapeDetection\Images\_bloodH_F.png")
                    .Resize(400, 400, Inter.Linear, true);

                UMat uimage = new UMat();
                CvInvoke.CvtColor(img, uimage, ColorConversion.Bgr2Gray);

                UMat pyrDown = new UMat();
                CvInvoke.PyrDown(uimage, pyrDown);
                CvInvoke.PyrUp(pyrDown, uimage);

                double cannyThreshold = 5.0;
                double circleAccumulatorThreshold = 39;
                CircleF[] circles = CvInvoke.HoughCircles(uimage, HoughType.Gradient, 1.6, 5, cannyThreshold, circleAccumulatorThreshold, 9, 15);

                return (object)circles.Length;
            }
            catch (Exception ex)
            {
                return (object)ex.InnerException;
            }
        }
    }
}