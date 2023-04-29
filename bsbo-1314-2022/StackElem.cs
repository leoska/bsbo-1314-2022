using System;
namespace bsbo_1314_2022
{
    public class StackElem : ListElem
    {
        public static StackElem tmp = new StackElem();

        private void StepTo(int index)
        {
            if (isEmpty())
            {
                throw new Exception("Stack is empty");
            }

            for(int i = 0; i < index; i++)
            {
                tmp.Push(Pop());

                if (isEmpty())
                {
                    ReturnFromTmp();

                    throw new Exception("Stack out of range");
                }
            }
        }

        private void ReturnFromTmp()
        {
            while (!tmp.isEmpty())
                Push(tmp.Pop());
        }

        public override int Get(int index)
        {
            StepTo(index);

            int result = top.value;

            ReturnFromTmp();

            return result;
        }

        public override void Set(int index, int newValue)
        {
            StepTo(index);

            top.value = newValue;

            ReturnFromTmp();
        }
    }
}

