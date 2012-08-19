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
                hiPiaoOperator = new MockHiPiaoOperator();
            }
            return hiPiaoOperator;
        }
    }
}
