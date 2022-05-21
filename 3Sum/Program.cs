using System;
using System.Collections.Generic;
namespace _3Sum
{
    //Given an integer array nums, return all the triplets[nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.
    //Notice that the solution set must not contain duplicate triplets.

    //Input: nums = [-1,0,1,2,-1,-4]
    //Output: [[-1,-1,2],[-1,0,1]]

    //Input: nums = []
    //Output: []

    //Input: nums = [0]
    //Output: []

    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { -1, 0, 1, 2, -1, -4 };
            int sum = 24;

            List<List<int>> triplets
              = findTriplets(nums, sum);
            findTriplets01(nums, 6, 0);
            // Function call
            if (triplets.Count != 0)
            {
                Console.Write("[");
                for (int i = 0; i < triplets.Count; i++)
                {
                    List<int> l = triplets[i];
                    Console.Write("[");
                    for (int j = 0; j < l.Count; j++)
                    {
                        Console.Write(l[j]);
                        if (l.Count != j + 1)
                            Console.Write(", ");
                    }
                    Console.Write("]");
                    if (triplets.Count != i + 1)
                        Console.Write(",");
                }
                Console.Write("]");
            }
            else
            {
                Console.WriteLine("No triplets can be formed");
            }
            Console.ReadKey();
        }
        public static List<List<int>> ThreeSum(int[] nums)
        {
            var res = new List<List<int>>();
            Array.Sort(nums);

            for (int i = 0; i < nums.Length; i++)
            {
                if (i != 0 && nums[i - 1] == nums[i])
                {
                    continue;
                }
                for (int start = i + 1, end = nums.Length - 1; start < end;)
                {
                    if (start != i + 1 && nums[start] == nums[start - 1])
                    {
                        start++;
                        continue;
                    }
                    if (nums[i] + nums[start] + nums[end] == 0)
                    {
                        res.Add(new List<int>() { nums[i], nums[start], nums[end] });
                        start++;
                    }
                    else if (nums[i] + nums[start] + nums[end] < 0)
                    {
                        start++;
                    }
                    else
                    {
                        end--;
                    }
                }
            }

            return res;
        }

        public static List<List<int>> findTriplets(int[] nums, int sum)
        {

            /* Sort the elements */
            Array.Sort(nums);

            List<List<int>> pair = new List<List<int>>();
            SortedSet<String> set = new SortedSet<String>();
            List<int> triplets = new List<int>();

            /* Iterate over the array from the start and
            consider it as the first element*/
            for (int i = 0;
                 i < nums.Length - 2;
                 i++)
            {

                // index of the first element in the
                // remaining elements
                int j = i + 1;

                // index of the last element
                int k = nums.Length - 1;

                while (j < k)
                {
                    if (nums[i]
                        + nums[j]
                        + nums[k] == 0)
                    {
                        String str = nums[i] + ":" + nums[j] + ":" + nums[k];

                        if (!set.Contains(str))
                        {

                            // To check for the unique triplet
                            triplets.Add(nums[i]);
                            triplets.Add(nums[j]);
                            triplets.Add(nums[k]);
                            pair.Add(triplets);
                            triplets = new List<int>();
                            set.Add(str);
                        }

                        j++; // increment the second value index
                        k--; // decrement the third value index
                    }
                    else if (nums[i]
                             + nums[j]
                             + nums[k] < 0)
                        j++;

                    else
                        k--;
                }
            }
            return pair;
        }
        static void findTriplets01(int[] a, int n, int sum)
        {
            int i;
            Array.Sort(a);
            bool flag = false;
            for (i = 0; i < n - 2; i++)
            {
                if (i == 0 || a[i] > a[i - 1])
                {
                    int start = i + 1;
                    int end = n - 1;
                    int target = sum - a[i];
                    while (start < end)
                    {
                        if (start > i + 1
                            && a[start] == a[start - 1])
                        {
                            start++;
                            continue;
                        }

                        if (end < n - 1
                            && a[end] == a[end + 1])
                        {
                            end--;
                            continue;
                        }
                        if (target == a[start] + a[end])
                        {
                            Console.Write("[" + a[i]
                                 + "," + a[start]
                                 + "," + a[end] + "] ");
                            flag = true;
                            start++;
                            end--;
                        }
                        else if (target > (a[start] + a[end]))
                        {
                            start++;
                        }
                        else
                        {
                            end--;
                        }
                    }
                }
            }
        }
    }
}
