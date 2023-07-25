using System;
using System.Diagnostics;

namespace MergeSort
{
    internal class Program
    {
        public static void MergeSort(int[] arr)
        {
            MergeSort(arr, 0, arr.Length - 1);
        }

        private static void MergeSort(int[] arr, int left, int right)
        {
            if(left<right)
            {
                int mid = (left + right) / 2;
                MergeSort(arr, left, mid);
                MergeSort(arr, mid + 1, right);
                Merge(arr, left, mid, right);
            }
        }

        private static void Merge(int[] arr, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;
            int[] leftArray = new int[n1];
            int[] rightArray = new int[n2];
            Array.Copy(arr, left, leftArray, 0, n1);
            Array.Copy(arr, mid+1, rightArray, 0, n2);
            int i = 0;
            int j = 0;
            int k = left;
            while(i<n1 && j<n2)
            {
                if (leftArray[i] <= rightArray[j])
                { arr[k] = leftArray[i];
                    i++;
                }
                else
                {
                    arr[k] = rightArray[j];
                    j++;
                }
                k++;
            }
            while(i<n1)
            {
                arr[k] = leftArray[i];
                i++;
                k++;
            }
            while(j<n2)
            {
                arr[k] = rightArray[j];
                j++;
                k++;
            }
        }

        static void Main(string[] args)
        {
            int[] arr = { 38, 27, 43, 3, 9, 82, 10 };
            Console.WriteLine("Original Array: "+string.Join(",",arr));
            Stopwatch stopwatch = new Stopwatch();    //Adding a stpwatch
            stopwatch.Start();
            MergeSort(arr);
            stopwatch.Stop();
            Console.WriteLine($"arraySize {arr.Length} Time Taken {stopwatch.Elapsed.TotalMilliseconds} milliseconds");
            Console.WriteLine("Merge Sorted Array: " + string.Join(",", arr));
            Console.ReadKey();
        }
    }
}
