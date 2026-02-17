namespace GLColorDemo
{
    public class Plane : Shape
    {


        protected override void SetShapeData()
        {

            vertices = new float[]
            {
                0.5f,  0.5f, 0.0f,
                0.5f, -0.5f, 0.0f,
                -0.5f, -0.5f, 0.0f,
                -0.5f,  0.5f, 0.0f,
            };
            colors = new float[]
            {
               1,0,0,1,
               1,0,0,1,
               1,0,0,1,
               1,0,0,1,
            };
            indices = new uint[]
            {
                0, 1, 3,
                1, 2, 3
            };

        }
    }
}

