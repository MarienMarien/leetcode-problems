<h2><a href="https://leetcode.com/problems/maximum-number-of-potholes-that-can-be-fixed/?envType=problem-list-v2&envId=string">3119. Maximum Number of Potholes That Can Be Fixed</a></h2><h3>Medium</h3><hr><p>You are given a string <code>road</code>, consisting only of characters <code>&quot;x&quot;</code> and <code>&quot;.&quot;</code>, where each <code>&quot;x&quot;</code> denotes a <em>pothole</em> and each <code>&quot;.&quot;</code> denotes a smooth road, and an integer <code>budget</code>.</p>

<p>In one repair operation, you can repair <code>n</code> <strong>consecutive</strong> potholes for a price of <code>n + 1</code>.</p>

<p>Return the <strong>maximum</strong> number of potholes that can be fixed such that the sum of the prices of all of the fixes <strong>doesn&#39;t go over</strong> the given budget.</p>

<p>&nbsp;</p>
<p><strong class="example">Example 1:</strong></p>

<div class="example-block">
<p><strong>Input:</strong> <span class="example-io">road = &quot;..&quot;, budget = 5</span></p>

<p><strong>Output:</strong> <span class="example-io">0</span></p>

<p><strong>Explanation:</strong></p>

<p>There are no potholes to be fixed.</p>
</div>

<p><strong class="example">Example 2:</strong></p>

<div class="example-block">
<p><strong>Input:</strong> <span class="example-io">road = &quot;..xxxxx&quot;, budget = 4</span></p>

<p><strong>Output:</strong> <span class="example-io">3</span></p>

<p><strong>Explanation:</strong></p>

<p>We fix the first three potholes (they are consecutive). The budget needed for this task is <code>3 + 1 = 4</code>.</p>
</div>

<p><strong class="example">Example 3:</strong></p>

<div class="example-block">
<p><strong>Input:</strong> <span class="example-io">road = &quot;x.x.xxx...x&quot;, budget = 14</span></p>

<p><strong>Output:</strong> <span class="example-io">6</span></p>

<p><strong>Explanation:</strong></p>

<p>We can fix all the potholes. The total cost would be <code>(1 + 1) + (1 + 1) + (3 + 1) + (1 + 1) = 10</code> which is within our budget of 14.</p>
</div>

<p>&nbsp;</p>
<p><strong>Constraints:</strong></p>

<ul>
	<li><code>1 &lt;= road.length &lt;= 10<sup>5</sup></code></li>
	<li><code>1 &lt;= budget &lt;= 10<sup>5</sup> + 1</code></li>
	<li><code>road</code> consists only of characters <code>&#39;.&#39;</code> and <code>&#39;x&#39;</code>.</li>
</ul>
