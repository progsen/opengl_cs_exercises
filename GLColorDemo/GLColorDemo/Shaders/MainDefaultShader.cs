using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace GLColorDemo.Shaders
{
    public class MainDefaultShader : Shader
    {
        public int texCoordLocation;
        public int vertexLocation;

        public MainDefaultShader(string vertPath, string fragPath) : base(vertPath, fragPath)
        {
        }
        public void Load()
        {
            Use();

            vertexLocation = GetAttribLocation("aPosition");
            texCoordLocation = GetAttribLocation("aColor");
        }


        internal void SetModelMatrix(Matrix4 tran)
        {
            SetMatrix4("model", tran);
        }
    }
}

