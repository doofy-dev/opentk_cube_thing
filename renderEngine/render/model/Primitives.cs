
namespace cube_thing.renderEngine.render.model
{
    public class Primitives
    {
        //TEXTURED TRIANGLE
        public static Mesh Triangle()
        {
            return new Mesh(
                    new float[]{	//verticles
						-0.5f,-0.5f,0,
                        0.5f,-0.5f,0,
                        0,0.5f,0,
                    },
                    new int[]{	//indices
						0,1,2
                    },
                    new float[]{	//normals
						0,0,1,
                        0,0,1,
                        0,0,1
                    },
                    new float[]{	//texturecoords
						0,0,
                        1,0,
                        0.5f,1
                    }
            );
        }



        public static Mesh Square()
        {
            return new Mesh(
                    new float[]{	//verticles
						-0.5f,-0.5f,0,
                        0.5f,-0.5f,0,
                        -0.5f,0.5f,0,
                        0.5f,0.5f,0
                    },
                    new int[]{	//indices
						0,1,2,
                        2,1,3
                    },
                    new float[]{	//normals
						0,0,1,
                        0,0,1,
                        0,0,1,
                        0,0,1,
                    },
                    new float[]{	//texturecoords
						0,0,
                        1,0,
                        0,1,
                        1,1
                    }
            );
        }

        public static Mesh Cube()
        {
            return new Mesh(
                    new float[]{	//verticles
						//BACK
						-0.5f,0.5f,-0.5f,
                        -0.5f,-0.5f,-0.5f,
                        0.5f,-0.5f,-0.5f,
                        0.5f,0.5f,-0.5f,

						//FRONT
						-0.5f,0.5f,0.5f,
                        -0.5f,-0.5f,0.5f,
                        0.5f,-0.5f,0.5f,
                        0.5f,0.5f,0.5f,

						//RIGHT
						0.5f,0.5f,-0.5f,
                        0.5f,-0.5f,-0.5f,
                        0.5f,-0.5f,0.5f,
                        0.5f,0.5f,0.5f,

						//LEFT
						-0.5f,0.5f,-0.5f,
                        -0.5f,-0.5f,-0.5f,
                        -0.5f,-0.5f,0.5f,
                        -0.5f,0.5f,0.5f,

						//TOP
						-0.5f,0.5f,0.5f,
                        -0.5f,0.5f,-0.5f,
                        0.5f,0.5f,-0.5f,
                        0.5f,0.5f,0.5f,

						//BOTTOM
						-0.5f,-0.5f,0.5f,
                        -0.5f,-0.5f,-0.5f,
                        0.5f,-0.5f,-0.5f,
                        0.5f,-0.5f,0.5f
                    },
                    new int[]{	//indices
						0,3,1,
                        1,3,2,

                        4,5,7,
                        7,5,6,

                        8,11,9,
                        9,11,10,

                        12,13,15,
                        15,13,14,

                        16,19,17,
                        17,19,18,

                        20,21,23,
                        23,21,22
                    },
                    //@TODO: fix
                    new float[]{	//normals
						-0.5f,0.5f,-0.5f,
                        -0.5f,-0.5f,-0.5f,
                        0.5f,-0.5f,-0.5f,
                        0.5f,0.5f,-0.5f,

                        -0.5f,0.5f,0.5f,
                        -0.5f,-0.5f,0.5f,
                        0.5f,-0.5f,0.5f,
                        0.5f,0.5f,0.5f,

                        0.5f,0.5f,-0.5f,
                        0.5f,-0.5f,-0.5f,
                        0.5f,-0.5f,0.5f,
                        0.5f,0.5f,0.5f,

                        -0.5f,0.5f,-0.5f,
                        -0.5f,-0.5f,-0.5f,
                        -0.5f,-0.5f,0.5f,
                        -0.5f,0.5f,0.5f,

                        -0.5f,0.5f,0.5f,
                        -0.5f,0.5f,-0.5f,
                        0.5f,0.5f,-0.5f,
                        0.5f,0.5f,0.5f,

                        -0.5f,-0.5f,0.5f,
                        -0.5f,-0.5f,-0.5f,
                        0.5f,-0.5f,-0.5f,
                        0.5f,-0.5f,0.5f
                    },
                    new float[]{	//texturecoords
						0,0,
                        0,1,
                        1,1,
                        1,0,
                        0,0,
                        0,1,
                        1,1,
                        1,0,
                        0,0,
                        0,1,
                        1,1,
                        1,0,
                        0,0,
                        0,1,
                        1,1,
                        1,0,
                        0,0,
                        0,1,
                        1,1,
                        1,0,
                        0,0,
                        0,1,
                        1,1,
                        1,0
                    }
            );
        }
    }
}
