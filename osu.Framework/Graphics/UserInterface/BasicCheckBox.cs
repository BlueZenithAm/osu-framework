﻿// Copyright (c) 2007-2016 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using OpenTK;
using OpenTK.Graphics;
using osu.Framework.Allocation;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Primitives;
using osu.Framework.Graphics.Sprites;

namespace osu.Framework.Graphics.UserInterface
{
    public class BasicCheckBox : CheckBox
    {
        public Color4 CheckedColor { get; set; } = Color4.Cyan;
        public Color4 UncheckedColor { get; set; } = Color4.White;
        public int FadeDuration { get; set; }

        public string LabelText
        {
            get { return labelSpriteText?.Text; }
            set
            {
                if (labelSpriteText != null)
                    labelSpriteText.Text = value;
            }
        }

        public MarginPadding LabelPadding
        {
            get { return labelSpriteText?.Padding ?? new MarginPadding(); }
            set
            {
                if (labelSpriteText != null)
                    labelSpriteText.Padding = value;
            }
        }

        private Box box;
        private SpriteText labelSpriteText;

        public BasicCheckBox()
        {
            AutoSizeAxes = Axes.Both;

            Children = new Drawable[]
            {
                new FlowContainer
                {
                    Direction = FlowDirection.HorizontalOnly,
                    AutoSizeAxes = Axes.Both,
                    Children = new Drawable[]
                    {
                        labelSpriteText = new SpriteText
                        {
                            Padding = new MarginPadding
                            {
                                Left = 10
                            },
                            Depth = float.MaxValue
                        },
                        box = new Box
                        {
                            Size = new Vector2(20, 20),
                        }
                    }
                }
            };
        }

        protected override void OnUnchecked() => box.FadeColour(UncheckedColor, FadeDuration);

        protected override void OnChecked() => box.FadeColour(CheckedColor, FadeDuration);
    }
}
