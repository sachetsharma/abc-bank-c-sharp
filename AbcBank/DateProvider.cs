using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcBank
{
    public class DateProvider
    {
        private static DateProvider instance = null;

        /// <summary>
        /// private constructor
        /// </summary>
        private DateProvider()
        { }

        public static DateProvider getInstance()
        {
            object lockHandle = new object();
            lock (lockHandle)
            {
                if (instance == null)
                    instance = new DateProvider();
            }
            return instance;
        }

        public DateTime now()
        {
            return DateTime.Now;
        }
    }
}
