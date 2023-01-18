using System;
using System.Collections.Generic;
using System.Text;

namespace PdfiumViewer
{
    public class GraphicsCoordinates
    {
        public GraphicsCoordinates(int pageIndex, PdfPoint point1, PdfPoint point2)
        {
            PageIndex = pageIndex;
            Point1 = point1;
            Point2 = point2;
        }

        public int PageIndex { get; }
        public PdfPoint Point1 { get; }
        public PdfPoint Point2 { get; }
        public bool IsEmpty => Point1 == Point2;
    }
}
