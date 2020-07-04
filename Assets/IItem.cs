﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItem : ICustomerDesires
{
    string Name { get; }
    Sprite Sprite { get; }
    string Description { get; }
    float PricePlayer { get; }
}
