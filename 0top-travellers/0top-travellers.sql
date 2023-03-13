# Write your MySQL query statement below
select 
u.name,
case when r.user_id is null then 0
    else r.travelled_distance
end as travelled_distance

from Users u
left join (select user_id, sum(distance) as travelled_distance from Rides group by user_id) r on u.id = r.user_id

order by travelled_distance desc, name asc