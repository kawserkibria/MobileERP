
using System.Collections.Generic;
using System.Linq;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;

using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

using System.Text;
using System.Threading.Tasks;

namespace JA.Modulecontrolar
{
   public static class Extensions
    {
        public static byte[] ToByteArray(this Image image)
        {
            if (image == null) return new byte[0];
            var ms = new MemoryStream();
            image.Save(ms, ImageFormat.Jpeg);
            return ms.ToArray();
        }
        //public static byte[] ToByteArray(this object image)
        //{
        //    if (image == null) return new byte[0];
        //    var ms = new MemoryStream();
        //    image.Save(ms, ImageFormat.Jpeg);
        //    return ms.ToArray();
        //}
        public static byte[] ToByteArray(this object image)
        {
            var imageByte = image as byte[];
            if (imageByte == null || imageByte.Length <= 0) return new byte[0];

            return imageByte;


        }
        public static void OnFormKeyDown(object sender, KeyEventArgs e)
        {
            var form = sender as Form;
            if (form == null) return;

            if (e.KeyCode == Keys.Escape)
                form.Close();
        }



        public static void MoveNext(this TextBox txtBox, Control ctrlNext)
        {
            txtBox.KeyDown += (sender, e) => OnTextBoxKeyDown(e, ctrlNext);
        }
        private static void OnTextBoxKeyDown(KeyEventArgs e, Control ctrlNext)
        {
            if (e.KeyCode != Keys.Enter) return;
            ctrlNext.Focus();
        }

        public static void ComboToNextTab(this ComboBox txtbox, Control clrnext)
        {
            txtbox.KeyDown += (sender, e) => OntextKeydown(e, clrnext);
        }

        static void OntextKeydown(KeyEventArgs e, Control clrnext)
        {
            if (e.KeyCode != Keys.Enter) return;
            clrnext.Focus();
        }




        public static void AllToNextTab(this Control crl1, Control crl2)
        {
            crl1.KeyDown += (sender, e) => ContrKeyDown(e, crl2);
        }

        static void ContrKeyDown(KeyEventArgs e, Control crl2)
        {
            if (e.KeyCode != Keys.Enter) return;
            crl2.Focus();
        }
        public static string ToStringNull(this object input)
        {
            return input == null ? String.Empty : Convert.ToString(input);
        }
    }
}
