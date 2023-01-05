using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    public class Sorting
    {
        // "Devide and conquer" idea.
        // Recursive
        // Two phases: splitting and merging
        // Splitting is logical: Provides an organized way to sequence the merges.
        // Note: NOT and in-place algorithm.
        // Uses significant amount of memory. Amount depends on n.
        // Stable: relative position mantained (in a classic implementation)
        // O (nlogn) time complexity (linearithmic)
        public static void MergeSort(int[] array)
        {
            int[] aux = new int[array.Length];
            Sort(0, array.Length - 1);

            void Sort(int low, int high)
            {
                if (high <= low)
                    return;
                
                int mid = (high + low) / 2;
                Sort(low, mid); //Split left side
                Sort(mid+1, high); //Split right side
                Merge(low, mid, high);
            }
            void Merge(int low, int mid, int high)
            {
                if (array[mid] <= array[mid + 1])
                    return;
                int i = low;
                int j = mid+1;

                Array.Copy(array, low, aux, low, high - low + 1);

                for(int k=low; k <= high; k++)
                {
                    if (i > mid) array[k] = aux[j++];
                    else if (j > high) array[k] = aux[i++];
                    else if (aux[j] < aux[i]) 
                        array[k] = aux[j++];
                    else
                        array[k] = aux[i++];
                }
            }
        }
        // "Devide and conquer" idea.
        // Recursive
        // In-place algorithm, don't have to use extra memory
        // typically O (nlogn) time complexity (linearithmic). But, O(n^2) (quadtratic) in extreamly rare, worst case scenario (inverse case).
        // Unstable
        public static void QuickSort(int[] array)
        {
            Sort(0, array.Length - 1);
            
            void Sort(int low, int high)
            {
                if (high <= low)
                    return;
                int j = Partition(low, high);
                Sort(low, j-1);
                Sort(j + 1, high);
            }

            int Partition(int low, int high)
            {
                int i = low;
                int j = high + 1;

                int pivot = array[low];
                while(true)
                {
                    while (array[++i] < pivot)
                    {
                        if (i == high)
                            break;
                    }

                    while(pivot < array[--j])
                    {
                        if(j == low)
                            break;
                    }

                    if(i >= j)
                        break;

                    Swap(array, i, j);
                }
                Swap(array, low, j);
                return j;
            }
        }
        private static void Swap(int[] array, int i, int j)
        {
            int tmp;
            tmp = array[i];
            array[i] = array[j];
            array[j] = tmp;
        }
    }
}
