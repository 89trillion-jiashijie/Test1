#region License and information
/* * * * *
 * 
 * Unity extension for the SimpleJSON framework. It does only work together with
 * the SimpleJSON.cs
 * It provides several helpers and conversion operators to serialize/deserialize
 * common Unity types such as Vector2/3/4, Rect, RectOffset, Quaternion and
 * Matrix4x4 as JSONObject or JSONArray.
 * This extension will add 3 static settings to the JSONNode class:
 * ( VectorContainerType, QuaternionContainerType, RectContainerType ) which
 * control what node type should be used for serializing the given type. So a
 * Vector3 as array would look like [12,32,24] and {"x":12, "y":32, "z":24} as
 * object.
 * 
 * 
 * The MIT License (MIT)
 * 
 * Copyright (c) 2012-2017 Markus Göbel (Bunny83)
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 * 
 * * * * */

#endregion License and information

using UnityEngine;

namespace SimpleJSON
{
    public enum JSONContainerType { Array, Object }
	public partial class JSONNode
	{
        public static JSONContainerType VectorContainerType = JSONContainerType.Array;
        public static JSONContainerType QuaternionContainerType = JSONContainerType.Array;
        public static JSONContainerType RectContainerType = JSONContainerType.Array;



    }
}
