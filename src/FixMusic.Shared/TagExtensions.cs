/*

Copyright (c) 2023 Gary Des Roches

Permission is hereby granted, free of charge, to any person
obtaining a copy of this software and associated documentation files
(the "Software"), to deal in the Software without restriction,
including without limitation the rights to use, copy, modify, merge,
publish, distribute, sublicense, and/or sell copies of the Software,
and to permit persons to whom the Software is furnished to do so,
subject to the following conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

Any person wishing to distribute modifications to the Software is
asked to send the modifications to the original developer so that
they can be incorporated into the canonical version.  This is,
however, not a binding provision of this license.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR
ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/

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
