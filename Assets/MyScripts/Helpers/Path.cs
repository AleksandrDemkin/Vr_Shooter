﻿using UnityEngine;
using System.Collections.Generic;

namespace GeekBrains.Helpers
{
    public class Path : MonoBehaviour
    {
        public Color LineColor = Color.red;
        private List<Transform> nodes = new List<Transform>();

		//Selected
		void OnDrawGizmos()
        {
            Gizmos.color = LineColor;

            Transform[] pathTransforms = GetComponentsInChildren<Transform>();
            nodes = new List<Transform>();

            for (int i = 0; i < pathTransforms.Length; i++)
            {
                if (pathTransforms[i] != transform)
                {
                    nodes.Add(pathTransforms[i]);
                }
            }

            for (int i = 0; i < nodes.Count; i++)
            {
                Vector3 currentNode = nodes[i].position;
                Vector3 previousNode = Vector3.zero;

                if (i > 0)
                {
                    previousNode = nodes[i - 1].position;
                }
                else if (i == 0 && nodes.Count > 1)
                {
                    previousNode = nodes[nodes.Count - 1].position;
                }
                Gizmos.DrawLine(previousNode, currentNode);
                Gizmos.DrawWireSphere(currentNode, 0.3f);
            }
        }

    }
}
