﻿/* =============================================================================
 * File:   PlistRoot.cs
 * Author: Cole Johnson
 * =============================================================================
 * Copyright (c) 2012 Cole Johnson
 * 
 * This file is part of Hexware.Plist
 * 
 * Hexware.Plist is free software: you can redistribute it and/or modify it
 *   under the terms of the GNU Lesser General Public License as published by
 *   the Free Software Foundation, either version 3 of the License, or (at your
 *   option) any later version.
 * 
 * Hexware.Plist is distributed in the hope that it will be useful, but WITHOUT
 *   ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or
 *   FITNESS FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public
 *   License for more details.
 * 
 * You should have received a copy of the GNU Lesser General Public License
 *   along with Hexware.Plist. If not, see <http://www.gnu.org/licenses/>.
 * =============================================================================
 */
using System;
using System.IO;
using System.Xml;

namespace Hexware.Plist
{
    /// <summary>
    /// Represents a &lt;plist /&gt; tag using <see cref="Hexware.Plist.PlistDict"/>
    /// </summary>
    public partial class PlistRoot
    {
        /// <summary>
        /// Hexware.Plist.PlistRoot constructor using a path
        /// </summary>
        /// <param name="value">The value of this node</param>
        /// <exception cref="System.ArgumentNullException"><paramref name="value"/> is null</exception>
        public PlistRoot(PlistDict value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            _value = value;
        }
    }
    public partial class PlistRoot
    {
        /// <summary>
        /// Read a binary Plist node into a .NET Plist element
        /// </summary>
        /// <param name="reader">The <see cref="System.IO.BinaryReader"/> that is responsible for deserializing the binary Plist</param>
        /// <param name="firstbyte">The first byte of this element as it was extracted from the reader stream</param>
        /// <param name="path">The path of this node</param>
        /// <param name="parent">A reference to the parent element of this element</param>
        /// <returns>The <see cref="Hexware.Plist.PlistRoot"/> element from the binary stream</returns>
        internal static PlistRoot ReadBinary(BinaryReader reader, byte firstbyte, string path, IPlistElement parent)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Write the Plist node to a <see cref="System.IO.BinaryWriter"/> for serializing the Plist as a Binary Plist
        /// </summary>
        /// <returns>An array of <see cref="System.Byte"/> that contains the data for this element</returns>
        internal byte[] WriteBinary()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Read an Xml Plist node into a .NET Plist element
        /// </summary>
        /// <param name="reader">The <see cref="System.Xml.XmlDocument"/> that is responsible for deserialization</param>
        /// <param name="index">The index of the element number of the <paramref name="reader"/> for this node</param>
        /// <param name="path">The path of this node</param>
        /// <param name="parent">A reference to the parent element of this element</param>
        /// <returns>The <see cref="Hexware.Plist.PlistRoot"/> element from the Xml stream</returns>
        internal static PlistRoot ReadXml(XmlDocument reader, int index, string path, IPlistElement parent)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Write the Plist node to an <see cref="System.Xml.XmlDocument"/> for serializing the Plist as an Xml Plist
        /// </summary>
        /// <param name="tree">The current node that the new element will be added to</param>
        /// <param name="writer">A <see cref="System.Xml.XmlDocument"/> that is used to create <see cref="System.Xml.XmlNode"/></param>
        /// <returns>An <see cref="System.Xml.XmlElement"/> that contains the value of this element</returns>
        internal void WriteXml(XmlNode tree, XmlDocument writer)
        {
            _value.WriteXml(tree, writer);
        }
    }
    public partial class PlistRoot : IPlistElement<PlistDict, Container>
    {
        internal PlistDict _value;

        /// <summary>
        /// Gets the Xml tag for this element
        /// </summary>
        public string Tag
        {
            get
            {
                return "plist";
            }
        }

        /// <summary>
        /// Gets or sets the value of this element
        /// </summary>
        public PlistDict Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        /// <summary>
        /// Gets or sets the path of this element
        /// </summary>
        public string Path
        {
            get
            {
                return "";
            }
        }

        /// <summary>
        /// Gets the type of this element as one of <see cref="Hexware.Plist.Container"/> or <see cref="Hexware.Plist.Primitive"/>
        /// </summary>
        public Container ElementType
        {
            get
            {
                return Container.Plist;
            }
        }

        /// <summary>
        /// Gets the parent of this element
        /// </summary>
        public IPlistElement Parent
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the length of this element when written in binary mode
        /// </summary>
        /// <returns>Containers return the amount inside while Primitives return the binary length</returns>
        public int GetPlistElementBinaryLength()
        {
            throw new NotImplementedException();
        }
    }
    public partial class PlistRoot : IDisposable
    {
        internal bool _disposed;

        /// <summary>
        /// Free up resources used on the system for garbage collector
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Free up resources used on the system for garbage collector
        /// </summary>
        /// <param name="disposing"><c>true</c> if called from .Dispose() or else <c>false</c></param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            // dispose all managed resources
            if (disposing)
            {
                _value.Dispose();
            }

            _disposed = true;
        }

        /// <summary>
        /// Free up resources used on the system for garbage collector
        /// </summary>
        ~PlistRoot()
        {
            Dispose(false);
        }
    }
}