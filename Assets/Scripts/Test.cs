using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        var subfolder = Path.Combine(path, "sub folder");

        var subpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + Path.DirectorySeparatorChar + "yourFolder";
    }

    // Update is called once per frame
    void Update()
    {

    }
}
