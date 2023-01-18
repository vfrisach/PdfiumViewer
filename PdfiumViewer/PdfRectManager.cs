using System;
using System.Collections.Generic;
using System.Drawing;

namespace PdfiumViewer
{
    /// <summary>
    /// Clase para dibujar un área seleccionada en el pdf
    /// </summary>
    public class PdfRectManager
    {
  
        private PdfRectangle _bounds;
        GraphicsCoordinates _coords = new GraphicsCoordinates(0,PdfPoint.Empty,PdfPoint.Empty);

        /// <summary>
        /// The renderer associated with the search manager.
        /// </summary>
        public PdfRenderer Renderer { get; }

  

    
      
        /// <summary>
        /// Gets or sets the color of the current match.
        /// </summary>
        public Color CurrentMatchColor { get; }

        /// <summary>
        /// Gets or sets the border color of the current match.
        /// </summary>
        public Color CurrentMatchBorderColor { get; }

        /// <summary>
        /// Gets or sets the border width of the current match.
        /// </summary>
        public float CurrentMatchBorderWidth { get; }


        /// <summary>
        /// Creates a new instance of the search manager.
        /// </summary>
        /// <param name="renderer">The renderer to create the search manager for.</param>
        public PdfRectManager(PdfRenderer renderer)
        {
            if (renderer == null)
                throw new ArgumentNullException(nameof(renderer));
            Renderer = renderer;
            CurrentMatchColor = Color.FromArgb(0x80, SystemColors.Highlight);
        }

        public string DrawRect(GraphicsCoordinates coords)
        {
            UpdateRect(coords);
            PdfTextSpan sp = new PdfTextSpan();
            Renderer.Document.GetWordAtPosition(coords.Point1, 1, 1, out sp);
            return Renderer.Document.GetPdfText(sp);
        }

        /// <summary>
        /// Resets the Rect manager.
        /// </summary>
        public void Reset()
        {
            Renderer.Markers.Clear();
            _bounds = new PdfRectangle(0, RectangleF.Empty);
        }

        private void UpdateRect(GraphicsCoordinates coords)
        {
            Renderer.Markers.Clear();
            var bounds = new RectangleF(
                    coords.Point1.Location.X - 1,
                    coords.Point1.Location.Y + 1,
                    coords.Point2.Location.X - coords.Point1.Location.X + 2,
                    coords.Point2.Location.Y - coords.Point1.Location.Y- 2);
            if (!discardRect(bounds))
            {
                var marker = new PdfMarker(coords.PageIndex, bounds, CurrentMatchColor, CurrentMatchColor, 1);
                Renderer.Markers.Add(marker);
            }
        }

        private bool discardRect(RectangleF rect)
        {
            return Math.Abs(rect.Height) < 5 || Math.Abs(rect.Width) < 5;
        }


      
    }
}
