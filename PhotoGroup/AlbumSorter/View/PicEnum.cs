namespace AlbumSorter.View
{
    using System;
    using System.Collections;

    public class PicEnum : IEnumerator
    {
        public string[] _stringList;
        private int position = -1;

        public PicEnum(string[] list)
        {
            this._stringList = list;
        }

        public int GetPosition()
        {
            return this.position;
        }

        public bool MoveNext()
        {
            this.position++;
            if (this.position <= this._stringList.Length)
            {
                return true;
            }
            this.position--;
            return false;
        }

        public bool MovePrevious()
        {
            this.position--;
            if (this.position > -1)
            {
                return true;
            }
            this.position++;
            return false;
        }

        public void Reset()
        {
            this.position = 0;
        }

        public string Current
        {
            get
            {
                string str;
                try
                {
                    str = this._stringList[this.position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
                return str;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return this.Current;
            }
        }
    }
}

