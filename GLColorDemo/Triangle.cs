namespace GLColorDemo
{
    //AI generated
    public class Triangle : Shape
    {
        protected override void SetShapeData()
        {
            // 3 vertices, each with (x, y, z)
            vertices = new float[]
            {
            -0.5f, -0.5f, 0.0f,  // 0: bottom-left
             0.5f, -0.5f, 0.0f,  // 1: bottom-right
             0.0f,  0.5f, 0.0f,  // 2: top (points up)
            };

            // One RGBA color per vertex (same color for all; tweak as you like)
            colors = new float[]
            {
            0,0,1,1,
            0,0,1,1,
            0,0,1,1,
            0,0,1,1
            };

            // Single triangle, CCW winding: 0 -> 1 -> 2
            indices = new uint[]
            {
            0, 1, 2
            };
        }
    }
}

