# Cafe POS System

Small-scale cafe point of sale (POS) system that operates with a MySQL database.


## The required MySQL tables

Database Name: cafe

"customers" Table:
```
+--------------+--------------+------+-----+---------+----------------+
| Field        | Type         | Null | Key | Default | Extra          |
+--------------+--------------+------+-----+---------+----------------+
| ID           | int          | NO   | PRI | NULL    | auto_increment |
| name         | varchar(255) | NO   |     | NULL    |                |
| table_number | int          | NO   | MUL | NULL    |                |
+--------------+--------------+------+-----+---------+----------------+
```

"items" Table:
```
+--------------+--------------+------+-----+---------+----------------+
| Field        | Type         | Null | Key | Default | Extra          |
+--------------+--------------+------+-----+---------+----------------+
| ID           | int          | NO   | PRI | NULL    | auto_increment |
| name         | varchar(255) | NO   | MUL | NULL    |                |
| price        | decimal(10,2)| NO   |     | NULL    |                |
+--------------+--------------+------+-----+---------+----------------+
```

"orders" Table:
```
+--------------+--------------+------+-----+---------+----------------+
| Field        | Type         | Null | Key | Default | Extra          |
+--------------+--------------+------+-----+---------+----------------+
| orderId      | int          | NO   | PRI | NULL    | auto_increment |
| item_name    | varchar(255) | NO   | MUL | NULL    |                |
| quantity     | int          | YES  |     | NULL    |                |
| table_number | int          | YES  | MUL | NULL    |                |
+--------------+--------------+------+-----+---------+----------------+
```


