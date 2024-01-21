using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Find
    {
        public int[,,] map;
        private int height, width, depth;
        private const int visited = 4;
        private const int seen = 2;

        public Find(int[,,] matrix)
        {
            this.height = matrix.GetLength(0);
            this.width = matrix.GetLength(1);
            this.depth = matrix.GetLength(2);
            this.map = matrix;
        }

        public Find(int height, int width, int depth)
        {
            this.height = height;
            this.width = width;
            this.depth = depth;
            this.map = new int[height, width, depth];
        }

        private int Exit(int coord, int border)
        {
            if (coord == 0 || coord == border - 1) return 1;
            return 0;
        }

        public void PutRandomNumberOne(int count)
        {
            Random rand = new Random();
            for (int i = 0; i < count; i++)
            {
                SetMap(rand.Next(height), rand.Next(width), rand.Next(depth), 1);
            }
        }

        private void SetMap(int x, int y, int z, int number) {
            if (x < 0 || x >= width) return;
            if (y < 0 || y >= height) return;
            if (z < 0 || z >= depth) return;
            map[x, y, z] = number;
        }

        private bool IsEmpty(int x, int y, int z)
        {
            if (x < 0 || x >= width) return false;
            if (y < 0 || y >= height) return false;
            if (z < 0 || z >= depth) return false;
            return map[x, y, z] == 0;
        }

        public int FindQueue(int pos_x, int pos_y, int pos_z)
        {
            int exits = 0;
            int x, y, z;

            SetMap(pos_x, pos_y, pos_z, seen);

            Queue<Matrix> queue = new Queue<Matrix>();
            queue.Enqueue(new Matrix(pos_x, pos_y, pos_z));

            while (queue.TryDequeue(out Matrix matrix))
            {
                x = matrix.x;
                y = matrix.y;
                z = matrix.z;

                exits += Exit(x, width) + Exit(y, height) + Exit(z, depth);


           
                                             

                SetMap(pos_x, pos_y, pos_z, visited);

                if (IsEmpty(x + 1, y, z)) { queue.Enqueue(new Matrix(x + 1, y, z)); SetMap(x + 1, y, z, seen); }
                if (IsEmpty(x - 1, y, z)) { queue.Enqueue(new Matrix(x - 1, y, z)); SetMap(x - 1, y, z, seen); }
                if (IsEmpty(x, y + 1, z)) { queue.Enqueue(new Matrix(x, y + 1, z)); SetMap(x, y + 1, z, seen); }
                if (IsEmpty(x, y - 1, z)) { queue.Enqueue(new Matrix(x, y - 1, z)); SetMap(x, y - 1, z, seen); }
                if (IsEmpty(x, y, z + 1)) { queue.Enqueue(new Matrix(x, y, z + 1)); SetMap(x, y, z + 1, seen); }
                if (IsEmpty(x, y, z - 1)) { queue.Enqueue(new Matrix(x, y, z - 1)); SetMap(x, y, z - 1, seen); }
            }
            return exits;
        }
    }
}
