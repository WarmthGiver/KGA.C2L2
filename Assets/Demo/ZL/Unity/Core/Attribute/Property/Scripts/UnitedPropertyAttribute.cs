using System;

using System.Collections.Generic;

using System.Reflection;

#if UNITY_EDITOR

using UnityEditor;

#endif

using UnityEngine;

using Object = UnityEngine.Object;

namespace ZL.Unity
{
    public abstract class UnitedPropertyAttribute : PropertyAttribute
    {
        protected const float singleLineHeight = 18f;

        protected const float singleSpaceHeight = 8f;

        protected const float singleIndentWidth = 15f;

        private string nameTag = null;

        public string NameTag
        {
            get
            {
                if (nameTag == null)
                {
                    nameTag = $"[{GetType().Name.RemoveFromBehind("Attribute")}]";
                }

                return nameTag;
            }
        }

#if UNITY_EDITOR

        public abstract bool Draw(Drawer drawer);

        [CustomPropertyDrawer(typeof(UnitedPropertyAttribute), true)]

        public sealed class Drawer : PropertyDrawer
        {
            private static readonly Dictionary<int, Dictionary<int, Info>> DrawerCaches = new();

            public SerializedProperty Property { get; private set; }

            public SerializedPropertyType PropertyType { get; private set; }

            public Object TargetObject { get; private set; }

            public Component TargetComponent { get; private set; }

            private int instanceID;

            private int fieldHashCode;

            public Info Current { get; private set; }

            private new UnitedPropertyAttribute attribute = null;

            public SerializedPropertyFieldType PropertyFieldType { get; set; }

            public float PropertyHeight { get; private set; } = 0f;

            private Rect PropertyPosition;

            private GUIContent PropertyLabel;

            private GUIStyle PropertyStyle;

            ~Drawer()
            {
                if (DrawerCaches.ContainsKey(instanceID) == true)
                {
                    if (DrawerCaches[instanceID].ContainsKey(fieldHashCode) == true)
                    {
                        DrawerCaches[instanceID].Remove(fieldHashCode);
                    }

                    if (DrawerCaches[instanceID].Count == 0)
                    {
                        DrawerCaches.Remove(instanceID);
                    }
                }
            }

            public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
            {
                if (Current == null)
                {
                    Property = property;

                    PropertyType = (SerializedPropertyType)Property.propertyType;

                    TargetObject = Property.serializedObject.targetObject;

                    TargetComponent = TargetObject as Component;

                    instanceID = TargetComponent.GetInstanceID();

                    //Debug.Log($"-----------------\n{TargetComponent.name}: {instanceID}");

                    if (DrawerCaches.ContainsKey(instanceID) == false)
                    {
                        DrawerCaches.Add(instanceID, new());
                    }

                    fieldHashCode = fieldInfo.GetHashCode();
                    
                    //Debug.Log($"{fieldInfo.Name}: {fieldHashCode}");
                    
                    if (DrawerCaches[instanceID].ContainsKey(fieldHashCode) == false)
                    {
                        var attributes = GetCustomAttributes(fieldInfo, typeof(UnitedPropertyAttribute));

                        DrawerCaches[instanceID].Add(fieldHashCode, new(attributes.Length, GUI.enabled, EditorGUI.indentLevel));
                    }

                    Current = DrawerCaches[instanceID][fieldHashCode];

                    attribute = (UnitedPropertyAttribute)base.attribute;
                }

                //Debug.Log($"Attribute: {attribute.NameTag}");

                //Debug.Log($"Current.hashCode: {Current.lastAttributeIndex}");

                //Debug.Log($"drawer: {attributeIndex}");

                PropertyFieldType = SerializedPropertyFieldType.Default;

                PropertyHeight = 0f;

                PropertyPosition = position;

                var enabled = GUI.enabled;

                var indentLevel = EditorGUI.indentLevel;

                attribute.Draw(this);

                if (Current.IsToggled == true)
                {
                    return;
                }

                GUI.enabled = Current.IsEnabled;

                EditorGUI.indentLevel = Current.IndentLevel + Current.SubIndentLevel;

                PropertyLabel = Current.NewLabel(this, label);

                switch (PropertyFieldType)
                {
                    case SerializedPropertyFieldType.Default:

                        EditorGUI.PropertyField(PropertyPosition, Property, new(" "), true);

                        PropertyPosition.x += Current.IndentLevel * singleIndentWidth;

                        PropertyPosition.width -= Current.IndentLevel * singleIndentWidth;

                        var labelPosition = PropertyPosition;

                        labelPosition.height = singleLineHeight;

                        int controlID = GUIUtility.GetControlID(FocusType.Passive);

                        PropertyStyle = Current.NewStyle(EditorStyles.label);

                        EditorGUI.HandlePrefixLabel(PropertyPosition, labelPosition, PropertyLabel, controlID, PropertyStyle);
                        
                        break;

                    case SerializedPropertyFieldType.Tag:

                        PropertyStyle = Current.NewStyle(EditorStyles.popup);

                        Property.stringValue = EditorGUI.TagField(PropertyPosition, PropertyLabel, Property.stringValue, PropertyStyle);

                        break;

                    case SerializedPropertyFieldType.Layer:

                        PropertyStyle = Current.NewStyle(EditorStyles.popup);

                        Property.intValue = EditorGUI.LayerField(PropertyPosition, PropertyLabel, Property.intValue, PropertyStyle);

                        break;

                    case SerializedPropertyFieldType.Empty:

                        EditorGUI.PropertyField(PropertyPosition, Property, GUIContent.none, false);

                        PropertyHeight -= EditorGUI.GetPropertyHeight(Property, PropertyLabel, true);

                        break;
                }

                EditorGUI.indentLevel = indentLevel;

                GUI.enabled = enabled;
            }

            public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
            {
                if (Current != null && Current.IsToggled == true)
                {
                    return 0f;
                }

                return EditorGUI.GetPropertyHeight(property, label, true) + PropertyHeight;
            }

            public bool IsFieldTypeIn(params Type[] types)
            {
                if (fieldInfo.FieldType.IsIncludedIn(types) == true)
                {
                    return true;
                }

                if (fieldInfo.FieldType.IsSubclassIn(types) == true)
                {
                    return true;
                }

                return false;
            }

            public bool IsPropertyTypeIn(params SerializedPropertyType[] types)
            {
                foreach (var type in types)
                {
                    if (PropertyType == type)
                    {
                        return true;
                    }
                }

                return false;
            }

            public bool IsPropertyNull()
            {
                return Property.objectReferenceValue == null;
            }

            public bool TryFindProperty(string name, SerializedPropertyType type, out SerializedProperty result)
            {
                if (TryFindProperty(name, out result) == true)
                {
                    if (result.propertyType == (UnityEditor.SerializedPropertyType)type)
                    {
                        return true;
                    }
                }

                return false;
            }

            public bool TryFindProperty(string name, out SerializedProperty result)
            {
                result = Property.serializedObject.FindProperty(name);

                /*if (property == null)
                {
                    var propertyPath = Property.propertyPath;

                    int index = propertyPath.LastIndexOf('.');

                    if (index == -1)
                    {
                        return false;
                    }

                    propertyPath = propertyPath[..index];

                    property = Property.serializedObject.FindProperty(propertyPath);

                    property = property.FindPropertyRelative(propertyName);
                }

                return true;*/

                return result != null;
            }

            public void DrawButton(float height, string methodName, string text)
            {
                var type = TargetObject.GetType();

                MethodInfo method = null;

                if (methodName != null)
                {
                    method = type.GetMethod(methodName);
                }

                var label = new GUIContent(text);

                var style = GUI.skin.button;

                var position = GUILayoutUtility.GetRect(label, style, GUILayout.Height(height));

                position.x += EditorGUIUtility.labelWidth + 2f;

                position.width -= EditorGUIUtility.labelWidth + 2f;

                if (GUI.Button(position, label, style) == true)
                {
                    method.Invoke(TargetObject, null);
                }

                if (method == null)
                {
                    DrawHelpBox(MessageType.Error, $"{attribute.NameTag} No method found matching \"{methodName}\".");
                }
            }

            public void DrawPreview()
            {
                var texture = AssetPreview.GetAssetPreview(Property.objectReferenceValue);

                if (texture == null)
                {
                    return;
                }

                var label = new GUIContent(texture);

                var style = GUI.skin.label;

                var position = GUILayoutUtility.GetRect(label, style);

                position.x += EditorGUIUtility.labelWidth;

                position.width = texture.width;

                position.height = texture.height;

                EditorGUI.LabelField(position, label);
            }

            public void DrawEmpty(float height = 8f)
            {
                DrawLine(height - 1f, Color.clear);
            }

            public void DrawLine(Color? color = null)
            {
                DrawLine(1f, color);
            }

            public void DrawLine(float height, Color? color = null)
            {
                Rect position = EditorGUILayout.GetControlRect(false, height);

                if (color == null)
                {
                    color = Utility.NormalTextColor;
                }

                EditorGUI.DrawRect(position, (Color)color);
            }

            public void DrawText(int? fontSize, FontStyle? fontStyle, Color? color, string text)
            {
                GUIStyle style = new(EditorStyles.label);

                if (fontSize != null)
                {
                    style.fontSize = (int)fontSize;
                }

                if (fontStyle != null)
                {
                    style.fontStyle = (FontStyle)fontStyle;
                }

                if (color != null)
                {
                    style.normal.textColor = (Color)color;
                }

                GUIContent label = new(text);

                Rect position = GUILayoutUtility.GetRect(label, style);

                EditorGUI.LabelField(position, label, style);
            }

            public void DrawHelpBox(string message)
            {
                DrawHelpBox(MessageType.None, IconSize.None, message);
            }

            public void DrawHelpBox(MessageType type, string message)
            {
                DrawHelpBox(type, IconSize.Small, message);
            }

            public void DrawHelpBox(MessageType type, IconSize iconSize, string message)
            {
                //EditorGUILayout.LabelField(GUIContent.none, new(message, Utility.GetHelpIcon(type, iconSize)), EditorStyles.helpBox);

                var label = new GUIContent(message, Utility.GetHelpIcon(type, iconSize));

                var style = EditorStyles.helpBox;

                EditorGUILayout.BeginHorizontal();

                var position = GUILayoutUtility.GetRect(label, style, GUILayout.ExpandHeight(true));

                EditorGUI.LabelField(position, label, style);

                EditorGUILayout.EndHorizontal();
            }

            public sealed class Info
            {
                public readonly int attributeLength;

                public bool IsToggled { get; set; } = false;

                public bool IsEnabled { get; set; }

                public int IndentLevel { get; set; }

                public int SubIndentLevel { get; set; }

                private string originalPropertyText = null;

                public string PropertyText { get; set; } = null;

                public string PropertyTooltip { get; set; } = null;

                public int? PropertyFontSize { get; set; } = null;

                public FontStyle? PropertyFontStyle { get; set; } = null;

                public Color? PropertyTextColor { get; set; } = null;

                private int drawCount = 0;

                public Info(int attributeCount, bool enabled, int indentLevel)
                {
                    attributeLength = attributeCount;

                    IsEnabled = enabled;

                    IndentLevel = indentLevel;
                }

                public GUIContent NewLabel(Drawer drawer, GUIContent label)
                {
                    GUIContent newLabel = new(label);

                    if (originalPropertyText == null)
                    {
                        originalPropertyText = label.text;
                    }

                    if (++drawCount != attributeLength)
                    {
                        newLabel.text = " ";
                    }

                    else
                    {
                        drawCount = 0;

                        if (PropertyText != null)
                        {
                            newLabel.text = PropertyText;
                        }

                        else
                        {
                            newLabel.text = originalPropertyText;
                        }
                    }

                    if (PropertyTooltip != null)
                    {
                        newLabel.tooltip = PropertyTooltip;
                    }

                    return newLabel;
                }

                public GUIStyle NewStyle(GUIStyle style)
                {
                    GUIStyle newStyle = new(style);

                    if (PropertyFontSize != null)
                    {
                        newStyle.fontSize = (int)PropertyFontSize;
                    }

                    if (PropertyFontStyle != null)
                    {
                        newStyle.fontStyle = (FontStyle)PropertyFontStyle;
                    }

                    var textColor = newStyle.normal.textColor;

                    if (PropertyTextColor != null)
                    {
                        textColor = (Color)PropertyTextColor;
                    }

                    newStyle.normal.textColor = textColor;

                    newStyle.hover.textColor = textColor;


                    return newStyle;
                }
            }
        }

        protected static class Utility
        {
            private static Color? normalTextColor = null;

            public static Color? NormalTextColor
            {
                get
                {
                    if (normalTextColor == null)
                    {
                        normalTextColor = EditorStyles.label.normal.textColor;
                    }

                    return normalTextColor;
                }
            }

            private static Texture2D smallInfoIcon = null;

            public static Texture2D SmallInfoIcon
            {
                get
                {
                    if (smallInfoIcon == null)
                    {
                        smallInfoIcon = LargeInfoIcon.ResizeTo(16, 16);
                    }

                    return smallInfoIcon;
                }
            }

            private static Texture2D largeInfoIcon = null;

            public static Texture2D LargeInfoIcon
            {
                get
                {
                    if (largeInfoIcon == null)
                    {
                        largeInfoIcon = EditorGUIUtility.FindTexture("console.infoicon@2x");
                    }

                    return largeInfoIcon;
                }
            }

            private static Texture2D smallWarningIcon = null;

            public static Texture2D SmallWarningIcon
            {
                get
                {
                    if (smallWarningIcon == null)
                    {
                        smallWarningIcon = LargeWarningIcon.ResizeTo(16, 16);
                    }

                    return smallWarningIcon;
                }
            }

            private static Texture2D largeWarningIcon = null;

            public static Texture2D LargeWarningIcon
            {
                get
                {
                    if (largeWarningIcon == null)
                    {
                        largeWarningIcon = EditorGUIUtility.FindTexture("console.warnicon@2x");
                    }

                    return largeWarningIcon;
                }
            }

            private static Texture2D smallErrorIcon = null;

            public static Texture2D SmallErrorIcon
            {
                get
                {
                    if (smallErrorIcon == null)
                    {
                        smallErrorIcon = LargeErrorIcon.ResizeTo(16, 16); ;
                    }

                    return smallErrorIcon;
                }
            }

            private static Texture2D largeErrorIcon = null;

            public static Texture2D LargeErrorIcon
            {
                get
                {
                    if (largeErrorIcon == null)
                    {
                        largeErrorIcon = EditorGUIUtility.FindTexture("console.erroricon@2x");
                    }

                    return largeErrorIcon;
                }
            }

            public static Texture2D GetHelpIcon(MessageType type, IconSize size)
            {
                return type switch
                {
                    MessageType.Info => GetInfoIcon(size),

                    MessageType.Warning => GetWarningIcon(size),

                    MessageType.Error => GetErrorIcon(size),

                    _ => null
                };
            }

            public static Texture2D GetInfoIcon(IconSize size)
            {
                return size switch
                {
                    IconSize.Small => SmallInfoIcon,

                    IconSize.Large => LargeInfoIcon,

                    _ => null
                };
            }

            public static Texture2D GetWarningIcon(IconSize size)
            {
                return size switch
                {
                    IconSize.Small => SmallWarningIcon,

                    IconSize.Large => LargeWarningIcon,

                    _ => null
                };
            }

            public static Texture2D GetErrorIcon(IconSize size)
            {
                return size switch
                {
                    IconSize.Small => SmallErrorIcon,

                    IconSize.Large => LargeErrorIcon,

                    _ => null
                };
            }
        }

#endif
    }
}