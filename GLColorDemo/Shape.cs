using OpenTK.Graphics.OpenGL4;
using GLColorDemo.Shaders;

namespace GLColorDemo
{
    public abstract class Shape
    {
        private float[] combinedVBO;
        public int stride = 7;
        protected float[] vertices;
        protected float[] colors;
        protected uint[] indices;

        private int indexBuffer;

        private int vertexBufferObject;

        private int vertexArrayObject;


        protected abstract void SetShapeData();
        public void Load(MainDefaultShader shader)
        {
            SetShapeData();
            //make buffer to send to the gfx card
            combinedVBO = new float[vertices.Length / 3 * 7];
            CreateCombinedBuffer();

            CreateVBO();

            CreateVertixAttributes(shader);//should always go after binding the VBO

            CreateIndexBuffer();
        }

        private void CreateVertixAttributes(MainDefaultShader shader)
        {
            vertexArrayObject = GL.GenVertexArray();//see shader EnableVertexAttribArray in the shader 
            GL.BindVertexArray(vertexArrayObject);

            GL.EnableVertexAttribArray(shader.vertexLocation);
            GL.VertexAttribPointer(shader.vertexLocation, 3, VertexAttribPointerType.Float, false, stride * sizeof(float), 0);
            GL.EnableVertexAttribArray(shader.texCoordLocation);
            GL.VertexAttribPointer(shader.texCoordLocation, 4, VertexAttribPointerType.Float, false, stride * sizeof(float), 3 * sizeof(float));
        }

        private void CreateVBO()
        {
            vertexBufferObject = GL.GenBuffer();
            BindVBOData();
        }

        public void BindVBOData()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, combinedVBO.Length * sizeof(float), combinedVBO, BufferUsageHint.StaticDraw);
        }

        private void CreateIndexBuffer()
        {
            indexBuffer = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, indexBuffer);
            GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), indices, BufferUsageHint.StaticDraw);
        }

        internal void CreateCombinedBuffer()
        {
            for (int i = 0, vi = 0; i < combinedVBO.Length; i += stride, vi += 3)
            {
                combinedVBO[i] = vertices[vi + 0];
                combinedVBO[i + 1] = vertices[vi + 1];
                combinedVBO[i + 2] = vertices[vi + 2];
            }
            SetColors(colors);
        }
        internal void SetColor(float[] color)
        {

            for (int i = 0; i < combinedVBO.Length; i += stride)
            {
                combinedVBO[i + 3] = color[0];
                combinedVBO[i + 4] = color[1];
                combinedVBO[i + 5] = color[2];
                combinedVBO[i + 6] = color[3];
            }
        }
        internal void SetColors(float[] colors)
        {

            for (int i = 0, ci = 0; i < combinedVBO.Length; i += stride, ci += 4)
            {
                combinedVBO[i + 3] = colors[ci];
                combinedVBO[i + 4] = colors[ci + 1];
                combinedVBO[i + 5] = colors[ci + 2];
                combinedVBO[i + 6] = colors[ci + 3];
            }
        }
        internal void Bind()
        {
            GL.BindVertexArray(vertexArrayObject);
        }

        internal void Renderer()
        {
            Bind();
            GL.DrawElements(PrimitiveType.Triangles, indices.Length, DrawElementsType.UnsignedInt, 0);
        }
    }
}

