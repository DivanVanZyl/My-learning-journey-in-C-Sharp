// "Devide and conquer" idea.
// Two phases: splitting and merging
// Splitting is logical: Provides an organized way to sequence the merges.
// Note: NOT and in-place algorithm.
// Uses significant amount of memory. Amount depends on n.
// Stable: relative position mantained (in a classic implementation)
// O (nlogn) time complexity (linearithmic)

using Merge_Sort;

int[] arr = new int[] { 1, 4, 2 };
Sorting.MergeSort(arr);
foreach(int i in arr)
    Console.Write(i);
