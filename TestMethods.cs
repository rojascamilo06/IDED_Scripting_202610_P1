namespace IDED_Scripting_202610_P1
{
    internal class TestMethods
    {
        public static void SeparateElements(Queue<int> input, out Stack<int> included, out Stack<int> excluded)
        {
            Stack<int> a = new Stack<int>();
            Stack<int> b = new Stack<int>();

            int n = input.Count;

            for (int i = 0; i < n; i++)
            {
                int x = input.Dequeue();
                bool ok = false;

                if (x != 0)
                {
                    int abs = x;
                    if (abs < 0) abs = -abs;

                    int r = (int)Math.Sqrt(abs);

                    if (r * r == abs)
                    {
                        if (r % 2 == 0 && x > 0) ok = true;
                        if (r % 2 != 0 && x < 0) ok = true;
                    }
                }

                if (ok) a.Push(x);
                else b.Push(x);

                input.Enqueue(x);
            }

            included = new Stack<int>();
            while (a.Count > 0) included.Push(a.Pop());

            excluded = new Stack<int>();
            while (b.Count > 0) excluded.Push(b.Pop());
        }

        public static List<int> GenerateSortedSeries(int n)
        {
            List<int> l = new List<int>();

            for (int i = 1; i <= n; i++)
            {
                int v = i * i;
                if (i % 2 != 0) v = -v;
                l.Add(v);
            }

            for (int i = 0; i < l.Count - 1; i++)
            {
                for (int j = 0; j < l.Count - 1 - i; j++)
                {
                    if (l[j] > l[j + 1])
                    {
                        int t = l[j];
                        l[j] = l[j + 1];
                        l[j + 1] = t;
                    }
                }
            }

            return l;
        }

        public static bool FindNumberInSortedList(int target, in List<int> list)
        {
            Console.Write("Ingrese el tamaño de la lista (impar): ");
            int n = int.Parse(Console.ReadLine());


            if (n % 2 == 0) n = n + 1;


            List<int> lista = new List<int>();
            Random rnd = new Random();

            for (int i = 0; i < n; i++)
            {

                lista.Add(rnd.Next(-50, 51));
            }

            Console.WriteLine("\nLista original:");
            for (int i = 0; i < lista.Count; i++)
            {
                Console.Write(lista[i]);
                if (i < lista.Count - 1) Console.Write(" ");
            }
            Console.WriteLine();


            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {

                    if (lista[j] < lista[j + 1])
                    {
                        int temp = lista[j];
                        lista[j] = lista[j + 1];
                        lista[j + 1] = temp;
                    }
                }
            }

            Console.WriteLine("\nLista ordenada (descendente):");
            for (int i = 0; i < lista.Count; i++)
            {
                Console.Write(lista[i]);
                if (i < lista.Count - 1) Console.Write(" ");
            }
            Console.WriteLine();


            Console.Write("\nIngrese el número a buscar: ");
            int objetivo = int.Parse(Console.ReadLine());

            bool encontrado = false;
            for (int i = 0; i < n; i++)
            {
                if (lista[i] == objetivo)
                {
                    encontrado = true;
                    break;
                }
            }
            
            if (encontrado)
                Console.WriteLine("\nResultado: SÍ está en la lista.");
            else
                Console.WriteLine("\nResultado: NO está en la lista.");

            return encontrado;
        }


        public static int FindPrime(in Stack<int> list)
        {
            Stack<int> t = new Stack<int>();
            int ans = 0;

            while (list.Count > 0)
            {
                int x = list.Pop();

                if (ans == 0 && IsPrime(x))
                    ans = x;

                t.Push(x);
            }

            while (t.Count > 0)
                list.Push(t.Pop());

            return ans;
        }

        public static bool IsPrime(int n)
        {
            if (n < 2) return false;

            for (int i = 2; i * i <= n; i++)
            {
                if (n % i == 0) return false;
            }

            return true;
        }

        public static Stack<int> RemoveFirstPrime(in Stack<int> stack)
        {
            Stack<int> t = new Stack<int>();
            bool removed = false;

            while (stack.Count > 0)
            {
                int x = stack.Pop();

                if (!removed && IsPrime(x))
                {
                    removed = true;
                }
                else
                {
                    t.Push(x);
                }
            }

            while (t.Count > 0)
                stack.Push(t.Pop());

            return stack;
        }

        public static Queue<int> QueueFromStack(Stack<int> stack)
        {
            Stack<int> t = new Stack<int>();
            Queue<int> q = new Queue<int>();

            while (stack.Count > 0)
            {
                int x = stack.Pop();
                q.Enqueue(x);
                t.Push(x);
            }

            while (t.Count > 0)
                stack.Push(t.Pop());

            return q;
        }
    }
}