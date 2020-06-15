using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshHighlighter : MonoBehaviour
{
    
    private MeshRenderer myRender;
    private Shader myShader;
    private Texture defaultTexture;



    void Start()
    {
        myRender = gameObject.GetComponent<MeshRenderer>();
        defaultTexture = myRender.material.mainTexture;
        // myShader.
    }

    // Update is called once per frame
    void Update()
    {
        myRender.material.shader = myShader;
    }
}
