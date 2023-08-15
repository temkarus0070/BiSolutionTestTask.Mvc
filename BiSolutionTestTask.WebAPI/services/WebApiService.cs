using BiSolutionTestTask.WebAPI.models;

namespace BiSolutionTestTask.WebAPI.services
{
    public class WebApiService
    {
        public long AddEverySecondOddNumber(int[] numbers)
        {
            bool isPreviousOdd = true;
            long sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 != 0 && !isPreviousOdd)
                {
                    isPreviousOdd = true;
                    sum += numbers[i];
                }
                else if (numbers[i] % 2 != 0 && isPreviousOdd)
                {
                    isPreviousOdd = false;
                }
            }
            return Math.Abs(sum);
        }

        public bool IsPalindrome(string str)
        {
            int left = 0;
            int right = str.Length - 1;
            while (left < right)
            {
                if (str[left] != str[right])
                {
                    return false;
                }
                do
                {
                    left++;
                }
                while (Char.IsWhiteSpace(str[left]));

                do
                {
                    right--;
                }
                while (Char.IsWhiteSpace(str[right]));
            }
            return true;
        }

        public MyDoubleLinkedList<int> Sort(List<int> list)
        {
            MyDoubleLinkedList<int> ints = new MyDoubleLinkedList<int>();
            foreach (var item in list)
            {
                ints.Add(item);
            }
            ints.Sort();
            return ints;
        }
    }
}
