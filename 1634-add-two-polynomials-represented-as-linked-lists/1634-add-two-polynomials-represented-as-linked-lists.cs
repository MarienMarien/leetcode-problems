/**
 * Definition for polynomial singly-linked list.
 * public class PolyNode {
 *     public int coefficient, power;
 *     public PolyNode next;
 *
 *     public PolyNode(int x=0, int y=0, PolyNode next=null) {
 *         this.coefficient = x;
 *         this.power = y;
 *         this.next = next;
 *     }
 * }
 */

public class Solution {
    public PolyNode AddPoly(PolyNode poly1, PolyNode poly2) {
        PolyNode head = new PolyNode();

        var curr = head;
        while (poly1 != null && poly2 != null)
        {
            if (poly1.coefficient == 0)
            {
                poly1 = poly1.next;
                continue;
            }
            if (poly2.coefficient == 0)
            {
                poly2 = poly2.next;
                continue;
            }

            if (poly1.power == poly2.power)
            {
                
                var newCoef = poly1.coefficient + poly2.coefficient;
                if (newCoef == 0)
                {
                    poly1 = poly1.next;
                    poly2 = poly2.next;
                    continue;
                }
                var newNode = new PolyNode(newCoef, poly1.power, null);
                curr.next = newNode;
                curr = curr.next;
                poly1 = poly1.next;
                poly2 = poly2.next;
                continue;
            }
            if (poly1.power > poly2.power)
            {
                curr.next = poly1;
                curr = curr.next;
                poly1 = poly1.next;
            }
            else { 
                curr.next = poly2;
                curr = curr.next;
                poly2 = poly2.next;
            }
        }
        curr.next = null;
        if (poly1 != null)
        {
            curr.next = poly1;
        }
        if (poly2 != null)
        {
            curr.next = poly2;
        }
        
        return head.next;
    }
}