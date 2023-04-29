using System;
namespace bsbo_1314_2022
{
	public class Element
	{
		public int value;
		public Element? next;

        public Element(int value = 0, Element? next = null)
        {
            this.value = value;
            this.next = next;
        }
    }

	public struct ElemValue
	{
		public int value;

        public ElemValue(int value = 0)
        {
            this.value = value;
        }
    }
}

