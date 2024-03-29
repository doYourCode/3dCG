﻿using OpenTK.Graphics.OpenGL4;


namespace Framework.Core.Vertex
{
    /// <summary>
    /// Enumeração dos atributos de vértice que são possíveis.
    /// </summary>
    public enum VertexAttributeType
    {
        Position,
        TexCoord_0,
        Normal,
        Tangent,
        Color,
        TexCoord_1,

        // TODO: BlendWeight, BlendIndices
    }


    /// <summary>
    /// Fornece os dados necessários para adicionar suporte aos atributos listados.
    /// </summary>
    public class VertexAttribute
    {
        /* ----------------------------------------- Variáveis de classe ----------------------------------------- */

        /// <summary>
        /// 
        /// </summary>
        private static readonly VertexAttribPointerType[] GetDataType =
        {
            VertexAttribPointerType.Float,              // Position
            VertexAttribPointerType.Float,              // TexCoord_0
            VertexAttribPointerType.Float,              // Normal
            VertexAttribPointerType.Float,              // Tangent
            VertexAttribPointerType.Float,              // Color
            VertexAttribPointerType.Float,              // TexCoord_1

            // TODO: BlendWeight = Float, BlendIndices = Int
        };

        /// <summary>
        /// 
        /// </summary>
        private static readonly UInt32[] GetSize =
        {
            3,                          // Position
            2,                          // TexCoord_0
            3,                          // Normal
            3,                          // Tangent
            3,                          // Color
            2,                          // TexCoord_1

            // TODO: BlendWeight = 1, BlendIndices = 2
        };

        /// <summary>
        /// 
        /// </summary>
        private static readonly UInt32[] GetDataTypeSize =
{
            sizeof(float),                          // Position
            sizeof(float),                          // TexCoord_0
            sizeof(float),                          // Normal
            sizeof(float),                          // Tangent
            sizeof(float),                           // Color
            sizeof(float),                          // TexCoord_1

            // TODO: BlendWeight = sizeof(float), BlendIndices = sizeof(int)
        };

        /* ---------------------------------------------- Variáveis membro ---------------------------------------------- */

        /// <summary>
        /// 
        /// </summary>
        public int Layout { get => (int)layout; private set { } }

        /// <summary>
        /// 
        /// </summary>
        public VertexAttribPointerType DataType { get => dataType; private set { } }

        /// <summary>
        /// 
        /// </summary>
        public uint Size { get => size; private set { } }

        /// <summary>
        /// 
        /// </summary>
        public uint SizeInBytes
        {
            get => size * dataTypeSize;

            private set { }
        }


        private int layout;

        private VertexAttribPointerType dataType;

        private UInt32 dataTypeSize;

        private UInt32 size;


        /* ---------------------------------------------- Interface pública ---------------------------------------------- */

        public VertexAttribute(VertexAttributeType Type)
        {
            this.layout = (int)Type;

            this.dataType = GetDataType[(int)Type];

            this.dataTypeSize = GetDataTypeSize[(int)Type];

            this.size = GetSize[(int)Type];
        }
    }
}
