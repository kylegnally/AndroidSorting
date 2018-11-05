/************************************************************************************
 *
 * Kyle Nally
 * CIS237 T/Th 3:30pm Assignment 4 - Algorithms: Modified Bucket Sort and Merge Sort
 * 11/3/2018
 *
 ************************************************************************************/

/**
 *  The {@code Merge} class provides static methods for sorting an
 *  array using mergesort.
 *  <p>
 *  For additional documentation, see <a href="https://algs4.cs.princeton.edu/22mergesort">Section 2.2</a> of
 *  <i>Algorithms, 4th Edition</i> by Robert Sedgewick and Kevin Wayne.
 *  For an optimized version, see {@link MergeX}.
 *
 *  @author Robert Sedgewick
 *  @author Kevin Wayne
 *
 *
 *  Modified for this purpose by Kyle Nally
 */

using System.Diagnostics;

namespace cis237_assignment4
{
    class MergeSort
    {
        // This class should not be instantiated.
        //private MergeSort() { }

        private IDroid[] Droids;
        private IDroid[] aux;
        /**
         * Reads in a sequence of strings from standard input; mergesorts them; 
         * and prints them to standard output in ascending order. 
         *
         * @param args the command-line arguments
         */
        public MergeSort(IDroid[] droids)
        {
            Droids = droids;
            Sort(Droids);
        }

        // stably merge a[lo .. mid] with a[mid+1 ..hi] using aux[lo .. hi]
        private static void Merge(IDroid[] a, IDroid[] aux, int lo, int mid, int hi)
        {

            // copy to aux[]
            for (int k = lo; k <= hi; k++)
            {
                aux[k] = a[k];
            }

            // merge back to a[]
            int i = lo, j = mid + 1;
            for (int k = lo; k <= hi; k++)
            {
                if (i > mid) a[k] = aux[j++];
                else if (j > hi) a[k] = aux[i++];
                else if (Less(aux[j], aux[i])) a[k] = aux[j++];
                else a[k] = aux[i++];
            }
        }

        // mergesort a[lo..hi] using auxiliary array aux[lo..hi]
        // this is called from inside the class
        private static void Sort(IDroid[] a, IDroid[] aux, int lo, int hi)
        {
            if (hi <= lo) return; // this is the base case
                                  // it's importat that the midpoint is done this way
            int mid = lo + (hi - lo) / 2;
            // left half
            Sort(a, aux, lo, mid);

            // right half
            Sort(a, aux, mid + 1, hi);

            // merge them
            Merge(a, aux, lo, mid, hi);
        }

        /**
         * Rearranges the array in ascending order, using the natural order.
         * @param a the array to be sorted
         */
        // this is called from the outside
        // the methods have different signatures so the recursive call will be made
        // to the above method
        private static void Sort(IDroid[] a)
        {
            IDroid[] aux = new IDroid[a.Length];
            Sort(a, aux, 0, a.Length - 1);
        }


        /***************************************************************************
         *  Helper sorting function.
         ***************************************************************************/

        // is v < w ?
        private static bool Less(IDroid v, IDroid w)
        {
            if (v == null /*|| w == null*/) return false;
            return v.CompareTo(w) < 0;
        }
    }
}
