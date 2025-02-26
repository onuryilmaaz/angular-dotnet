import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';

@Component({
  selector: 'app-product',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './product.component.html',
  styleUrl: './product.component.css',
})
export class ProductComponent {
  products = [
    {
      id: 1,
      name: 'Product 1',
      img: '../../../assets/images/1.jpg',
      desc: 'This is the description for Product 1. It is a great item!',
      price: 19.99,
      status: true,
    },
    {
      id: 2,
      name: 'Product 2',
      img: '../../../assets/images/2.jpg',
      desc: 'This is the description for Product 2. It has amazing features!',
      price: 29.99,
      status: true,
    },
    {
      id: 3,
      name: 'Product 3',
      img: '../../../assets/images/3.jpg',
      desc: 'This is the description for Product 3. A must-have for everyone!',
      price: 39.99,
      status: true,
    },
    {
      id: 4,
      name: 'Product 4',
      img: '../../../assets/images/4.jpg',
      desc: 'This is the description for Product 4. Top-quality product!',
      price: 49.99,
      status: false,
    },
    {
      id: 5,
      name: 'Product 5',
      img: '../../../assets/images/5.jpg',
      desc: 'This is the description for Product 5. Very useful and affordable.',
      price: 59.99,
      status: true,
    },
    {
      id: 6,
      name: 'Product 6',
      img: '../../../assets/images/6.jpg',
      desc: 'This is the description for Product 6. Highly recommended!',
      price: 69.99,
      status: false,
    },
    {
      id: 6,
      name: 'Product 7',
      img: '../../../assets/images/6.jpg',
      desc: 'This is the description for Product 6. Highly recommended!',
      price: 69.99,
      status: false,
    },
    {
      id: 6,
      name: 'Product 6',
      img: '../../../assets/images/6.jpg',
      desc: 'This is the description for Product 6. Highly recommended!',
      price: 69.99,
      status: false,
    },
    {
      id: 6,
      name: 'Product 6',
      img: '../../../assets/images/6.jpg',
      desc: 'This is the description for Product 6. Highly recommended!',
      price: 69.99,
      status: false,
    },
    {
      id: 6,
      name: 'Product 6',
      img: '../../../assets/images/6.jpg',
      desc: 'This is the description for Product 6. Highly recommended!',
      price: 69.99,
      status: false,
    },
  ];
}
