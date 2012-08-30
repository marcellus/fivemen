using System;
using System.Collections.Generic;
using System.Text;

namespace HiPiaoInterface
{
    public class HiPiaoOperatorFactory
    {
        private HiPiaoOperatorFactory()
        {
        }
        private static IHiPiaoOperator hiPiaoOperator;
        public static IHiPiaoOperator GetHiPiaoOperator()
        {
            if (hiPiaoOperator == null)
            {
                hiPiaoOperator = new HiPiaoOperator();
            }
            return hiPiaoOperator;
        }


        private static IHiPiaoOperator mockHiPiaoOperator;
        public static IHiPiaoOperator GetMockHiPiaoOperator()
        {
            if (mockHiPiaoOperator == null)
            {
                mockHiPiaoOperator = new MockHiPiaoOperator();
            }
            return mockHiPiaoOperator;
        }
    }
}
