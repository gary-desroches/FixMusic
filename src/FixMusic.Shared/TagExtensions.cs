using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagLib;

namespace FixMusic
{
    public static class TagExtensions
    {
        public static readonly ReadOnlyByteVector TRCK = "TRCK";

        public static (uint part, uint total) GetPartAndTotal(this TagLib.Id3v2.Tag instance, ReadOnlyByteVector ident)
        {
            var pieces = instance.GetTextAsString(ident).Split(new char[] { '/' });
            if (pieces.Length == 2)
            {
                return (uint.Parse(pieces[0]), uint.Parse(pieces[1]));
            }
            else if (pieces.Length == 1)
            {
                return (uint.Parse(pieces[0]), 0);
            }
            else
            {
                return (0, 0);
            }
        }

        public static (uint track, uint trackTotal) GetTrackAndTotal(this TagLib.Id3v2.Tag instance) => 
            instance.GetPartAndTotal(TRCK);

        public static bool SetTrackAndTotal(this TagLib.Id3v2.Tag instance, uint track, uint trackTotal)
        {
            return instance.SetPartAndTotal(TRCK, track, trackTotal);
        }

        private static bool SetPartAndTotal(this TagLib.Id3v2.Tag instance, ReadOnlyByteVector ident, uint part, uint total)
        {
            bool wasChanged = false;
            string currentValue = instance.GetTextAsString(TRCK);
            if (currentValue is null)
            {
                currentValue = "";
            }
            else
            {
                currentValue = currentValue.Trim();
            }

            if (total > 0)
            {
                string valueText = string.Join("/", new string[] { part.ToString(), total.ToString() });
                if (String.Compare(currentValue, valueText) != 0)
                {
                    instance.SetTextFrame(TRCK, valueText);
                    wasChanged = true;
                }
            }
            else
            {
                string valueText = part.ToString().Trim();
                if (String.Compare(currentValue, valueText) != 0)
                {
                    instance.SetTextFrame(TRCK, part.ToString());
                    wasChanged = true;
                }
            }

            return wasChanged;
        }
    }
}
