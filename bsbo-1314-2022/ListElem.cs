using System;
using System.Reflection;

namespace bsbo_1314_2022
{
	public class ListElem
	{
		protected Element? top = null;

		// Возвращает указатель на i-ый элемент в листе (по индексу)
        private Element GetByIndex(int index)
        {
            if (isEmpty())
            {
                throw new Exception("ListElem is empty");
            }

            Element current = top;

            for (int i = 0; i < index; i++)
            {
                current = current.next;

                if (current == null)
                {
                    throw new Exception("ListElem out of range");
                }
            }

            return current;
        }

		// Проверяем, пустой ли у нас список
        public bool isEmpty()
		{
			return top == null;
        }

		// Добавляем новый элемент в лист
		public void Push(Element elem)
		{
			if (!isEmpty())
			{
				elem.next = top;
            }

			top = elem;
		}

		// Извлекаем элемент из листа
		public Element Pop()
		{
			if (isEmpty())
			{
				throw new Exception("ListElem is empty");
			}

			Element result = top;

			top = top.next;
			result.next = null;

            return result;
		}

		// Вывод содержимого листа в консоли
		public void Print()
		{
			Element current = top;

			while(current != null)
			{
				Console.Write($"{current.value} ");
				current = current.next;
			}

			Console.WriteLine();
		}

        // Получение value у i-ого элемента
        public virtual int Get(int index)
		{
			Element current = GetByIndex(index);

            return current.value;
        }

        // Перезапись value у i-ого элемента
        public virtual void Set(int index, int newValue)
        {
            Element current = GetByIndex(index);

            current.value = newValue;
        }

		// Перегрузка оператора индексации [] (как у массива)
		public int this[int index]
		{
			get => Get(index);
			set => Set(index, value);
		}
    }
}

