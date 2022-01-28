using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestIncreasingSubsequenceLen
{
    internal class Program
    {
         
        static void Main(string[] args)
        {
            Program program = new Program();
            //List<int> A = new List<int>() { 1 };
            //{ 69, 54, 19, 51, 16, 54, 64, 89, 72, 40, 31, 43, 1, 11, 82, 65, 75, 67, 25, 98, 31, 77, 55, 88, 85, 76, 35, 101, 44, 74, 29, 94, 72, 39, 20, 24, 23, 66, 16, 95, 5, 17, 54, 89, 93, 10, 7, 88, 68, 10, 11, 22, 25, 50, 18, 59, 79, 87, 7, 49, 26, 96, 27, 19, 67, 35, 50, 10, 6, 48, 38, 28, 66, 94, 60, 27, 76, 4, 43, 66, 14, 8, 78, 72, 21, 56, 34, 90, 89 };
            //program.lis(A);
            //program.PascalTriangle();
            List<int> arr = program.getRow(4);
        }

        public int lis(List<int> arr)
        {
            List<int> lis = new List<int> (Enumerable.Repeat(1,arr.Count));
            int i, j, max = 1;                        

            for (i = 0; i < arr.Count; i++)
                for (j = 0; j < i; j++)
                    if (arr[i] > arr[j])
                    {
                        lis[i] = Math.Max(lis[i], lis[j] + 1);
                        max = Math.Max(max, lis[j] + 1);
                    }

            return max;
        }

        public bool DetectCapitalUse()
        {
            string word = "HELL";
            if (string.IsNullOrEmpty(word))
                return true;
            bool isFirstCapital = ((byte)word[0]) <97 ;
            bool isExpectSmallLetter = false, isExpectLargeLetter = false;
            for (int i =1;i<word.Length;i++)
            {
                if(isFirstCapital)
                {
                    if (((byte)word[i]) < 97 && !isExpectSmallLetter)
                        isExpectLargeLetter = true;
                    else if (((byte)word[i]) >96 && !isExpectLargeLetter)
                        isExpectSmallLetter = true;
                    else
                        return false;
                }
                else
                {
                    if (((byte)word[i]) < 97)
                        return false;
                }

            }
            return true;
        }

        public void PascalTriangle()
        {
            int len = 5;
            int[,] a = new int[len, len];
            for (int i = 0; i < len; i++)
            {
                for(int j = 0; j <=i; j++)
                {
                    if (j == 0 || j == i)
                        a[i, j] = 1;                        
                    else
                        a[i, j] = a[i - 1, j - 1]+ a[i - 1, j ];

                    Console.Write(a[i, j] + " ");
                }
                Console.WriteLine("");
            }
        }

        public List<int> getRow1(int rowIndex)
        {
            //List<int> currRow = new List<int>();
            
            //currRow.Add(1);
            //if (A == 0)
            //    return currRow;

            //List<int> prev = getRow(A-1);
            //for(int i = 1;i < currRow.Count;i++)
            //{
            //    int curr= prev[i]+ prev[i-1];
            //    currRow.Add(curr);
            //}
            //currRow.Add(1);

            //return currRow;


            List<int> currow = new List<int>();
            currow.Add(1);

            if (rowIndex == 0)
            {
                return currow;
            }

            List<int> prev = getRow(rowIndex - 1);

            for (int i = 1; i < prev.Count; i++)
            {
                int curr = prev[i - 1] + prev[i];
                currow.Add(curr);
            }
            currow.Add(1);

            // Return the row
            return currow;
        }


        public List<int> getRow(int rowIndex)
        {
            List<int> currow = new List<int>();

            // 1st element of every row is 1
            currow.Add(1);

            // Check if the row that has to
            // be returned is the first row
            if (rowIndex == 0)
            {
                return currow;
            }
            // Generate the previous row
            List<int> prev = getRow(rowIndex - 1);

            for (int i = 1; i < prev.Count; i++)
            {

                // Generate the elements
                // of the current row
                // by the help of the
                // previous row
                int curr = prev[i - 1] + prev[i];
                currow.Add(curr);
            }
            currow.Add(1);

            // Return the row
            return currow;
        }

        //public int lis(List<int> A)
        //{
        //    int maxLen = 0, currLen = 0, prevVar = 0;

        //    for (int i = 0; i < A.Count; i++)
        //    {
        //        currLen++;
        //        prevVar = A[i];
        //        for (int j = i + 1; j < A.Count; j++)
        //        {
        //            if (A[j] > prevVar)
        //            {
        //                currLen++;
        //                prevVar=A[j];
        //            }
        //        }
        //        if (currLen > maxLen)
        //            maxLen = currLen;
        //        currLen = 0;
        //    }

        //    return maxLen;
        //}
    }
}
