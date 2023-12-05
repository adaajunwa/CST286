using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Sorts
{
    //Implements the HeapSort method of the ISorts Interface; Performs a Heap sort on elements in an array
    public void HeapSort(int[] a)
    {
        BuildMaxHeap(a);// Call BuildMaxHeap method
        for (int i = a.Length - 1; i > 0; i--)//starting from lenght of array to 0, and decrementing by 1 as we go
        {
            // Swap 1st element in max heaped array with last element
            int last = a[i]; //store last element in first
            a[i] = a[0]; //copy first element to last element
            a[0] = last; //copy last element in last to first element
            MaxHeapify(a, i, 1); // Call MaxHeapify using array, current array lenght, and numeric representation of the root
        }
    }

    // Creates a max heap from the array elements
    private void MaxHeapify(int[] a, int size, int i)
    {
        int l = (2 * i);//numeric representation of any left child of i
        int r = 2 * i + 1; //numeric representation of any right child of i
        int largest = i;//variable to store the largest between parent and children representation
        if (l <= size && a[l - 1] > a[i - 1])//If left child representation of i is <= array lenght, and left child element > parent element
        {
            largest = l;// make left child representation the largest
        }

        if (r <= size && a[r - 1] > a[largest - 1])//If right child representation of i is <= array lenght, and left right element > left child element
        {
            largest = r; // make left child representation the largest
        }

        if (largest != i) //parent node representation i was not initially max heaped
        {
            //Swap elements parent element with larger of children
            int first = a[i - 1];//copy parent element of i to first
            //int last = a[largest - 1];
            a[i - 1] = a[largest - 1];// copy larger child element to parent element
            a[largest - 1] = first;// copy first to larger child element

            MaxHeapify(a, size, largest);// call MaxHeapify using array, array lenght and largest child representation
        }
    }

    //Builds an initial max heap from an array (without including its leaves)
    private void BuildMaxHeap(int[] a)
    {
        int size = a.Length;// initialize array lenght
        double z = Convert.ToDouble(size);// Convert size to a double
        for (int i = Convert.ToInt32(Math.Floor(z / 2)); i > 0; i--)//From i as floor(array lenght/2) to the 1st index,
                                                                    //decrementing as we go by 1 (start from the last node that is not a leaf)
        {
            MaxHeapify(a, size, i);// Call heapify with array, array lenght and specific unheaped node i
        }

    }



//Implements the QuickSort method of the ISorts Interface; Performs a quick sort on elements in an array
public void QuickSort(int[] a)
    {
        int lb = 0;// initialize lb as 1st index
        int ub = a.Length - 1;// initialize ub as last index
        QuickSortRec(a, lb, ub);// call QuickSortRec using array, 1st and last index
    }

    //Quick sort recursive helper
    private void QuickSortRec(int[] a, int lb, int ub)
    {
        if (lb < ub)// If 1st index < last index
        {
            int loc = QuickPartition(a, lb, ub);// call QuickPartition on array, 1st and last index, and store as sorted pivot index
            QuickSortRec(a, lb, loc - 1);//Recursively call QuickSortRec on array partition before the sorted pivot index
            QuickSortRec(a, loc + 1, ub); //Recursively call QuickSortRec on array partition after the sorted pivot index
        }
    }
    //Partitions the array; all elements < pivot to the left of pivot, and all elements > pivot to the right of pivot 
    // returns the index location of pivot
    private int QuickPartition(int[] a, int lb, int ub)
    {
        int pivot = a[lb];//Initialize pivot as 1st element in array
        int end = ub;// Initialize end as last index in array
        int start = lb;// initialize start as 1st index in array
        while (start < end) // while start < end
        {
            //Go through loop while element with index start <= pivot
            while (a[start] <= pivot)
            {
                start++;// move start 1 index to the right
            }

            //Go through loop while element with index end > pivot
            while (a[end] > pivot)
            {
                end--;// move end 1 index to the left
            }
            if (start < end) //if start index < end index
            {
                // swap element in start index with element in end index
                int first = a[start];// store element in start index in first
                a[start] = a[end]; // copy element in end index to element in start index
                a[end] = first; // copy first to element in end index
            }

        }
        //Swap pivot element with element in end index
        int temp = a[lb];// store pivot element in temp variable
        a[lb] = a[end];//Copy element in end index to pivot element
        a[end] = temp;// Copy temp to element in end index 
        return end;//Return new location of pivot element
    }
        public void InsertionSort(int[] a)
        
    {
        int n = a.Length;// initialize lenght of array
        for (int i = 1; i < n; i++)// Start from 2nd index till end of array (unsorted partition). Increment by 1
        {
            int temp = a[i];//Store element in index i in temp
            int j = i - 1; //store in j; element 1 step to the left of i (last element in sorted partition)
            while (j >= 0 && a[j] > temp)// While we have not reached the first item in sorted partition,
                                         // and element j in sorted partition > temp
            {
                a[j + 1] = a[j];// copy element j one step to the right (into the hole)
                j--;// decrement j by 1 (move 1 step to the left)
            }
            a[j + 1] = temp;// insert temp into the hole
        }
    }
}
