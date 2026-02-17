using System;

namespace GLColorDemo
{
    //AI generated
    public class Circle : Shape
    {
        private readonly float radius;

        public Circle(float radius = 0.5f)
        {
            this.radius = radius;
        }

        protected override void SetShapeData()
        {
            int n = 8; // 8-point circle (regular octagon)
            vertices = new float[n * 3];
            colors = new float[n * 4];
            indices = new uint[(n - 2) * 3];

            // Generate 8 points on a circle (counter-clockwise, +Z facing)
            for (int i = 0; i < n; i++)
            {
                float theta = (float)(i * 2.0 * Math.PI / n);
                float x = radius * (float)Math.Cos(theta);
                float y = radius * (float)Math.Sin(theta);

                int vi = i * 3;
                vertices[vi + 0] = x;
                vertices[vi + 1] = y;
                vertices[vi + 2] = 0f;

                int ci = i * 4;
                colors[ci + 0] = 0; // R
                colors[ci + 1] = 1; // G
                colors[ci + 2] = 0; // B
                colors[ci + 3] = 1.00f; // A
            }

            // Triangulate the convex polygon by fanning from vertex 0
            int idx = 0;
            for (uint i = 1; i < n - 1; i++)
            {
                indices[idx++] = 0;
                indices[idx++] = i;
                indices[idx++] = i + 1;
            }
        }
    }
}

