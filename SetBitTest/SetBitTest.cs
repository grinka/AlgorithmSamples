using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetBitTest
{
    public class SetBitTest
    {
        private uint[] _container;
        private const uint One = 1;

        public SetBitTest() {
            _container = new uint[100];
        }

        public void Test() {
            // x      = 172
            // x / 32 =   5
            //          
            // x % 32 =  12
            uint data = 173;
            //Console.WriteLine(data);
            //var div32 = data >> 5;
            //Console.WriteLine(div32);
            //var less = data - (div32 << 5);
            //Console.WriteLine(less);
            // Set the bit number x % 32
            SetVal(data);
            Console.WriteLine("Is set 34 : {0}", IsSet(34) );
            Console.WriteLine("Is set 171: {0}", IsSet(171));
            Console.WriteLine("Is set 173: {0}", IsSet(173));
            Console.ReadKey();
        }

        public void SetVal(uint val) {
            var index = val >> 5;
            var less = val - (index << 5);
            var newVal = _container[index] | One << (int) less;
            _container[index] = newVal;
        }

        public bool IsSet(uint val) {
            var index = val >> 5;
            var less = val - (index << 5);
            var compareVal = One << (int) less;
            return (_container[index] & compareVal) != 0;
        }

    }
}
