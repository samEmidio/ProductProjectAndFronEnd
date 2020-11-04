import { ProductsService } from './../../services/products/products.service';
import { CategoryService } from './../../services/category/category.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

  
  categories = [];
  products = [];

  newCategory = {
    name:"",
    description:""
  };

  newCategoryUpdate = {
    id:0,
    name:"",
    description:""
  };

  newProduct = {
    name:"",
    description:"",
    price:0.0,
    categoryId:0,
    pictures:[]
  }

  newProductUpdate = {
    id:0,
    name:"",
    description:"",
    price:0.0,
    categoryId:0,
    pictures:[]
  }


  filesToUpload: Array<File> = [];

  constructor(private categoryService:CategoryService, private productService:ProductsService) { }

  ngOnInit(): void {
    this.getCategories();
    this.getProducts();
  }


  getCategories(){
    var response = this.categoryService.getCategories();

    response.subscribe(x => {
      this.categories = x;
    },error=>{
      console.log(error.message)
    })
  }

  getProducts(){
    var response = this.productService.getProducts();

    response.subscribe(x => {
      this.products = x;
    },error=>{
      console.log(error.message)
    })
  }

  addCategory(){

    var response = this.categoryService.create(this.newCategory);

    response.subscribe(x => {
      this.getCategories();
    },error=>{
      console.log(error.message)
      alert('algum campo não foi preenchido corretamente')
    })

  }

  updateCategory(){
    var response = this.categoryService.update(this.newCategoryUpdate.id,this.newCategoryUpdate);
    response.subscribe(x => {
      this.getCategories();
    },error=>{
      console.log(error.message)
    })
  }

  deleteCategory(){
    var response = this.categoryService.delete(this.newCategoryUpdate.id);
    response.subscribe(x => {
      this.getCategories();
    },error=>{
      console.log(error.message)
    })
  }
  deleteProduct(){
    var response = this.productService.delete(this.newProductUpdate.id);
    response.subscribe(x => {
      this.getProducts();
    },error=>{
      console.log(error.message)
    })
  }

  selectCategory(category){
    this.newCategoryUpdate = category;
  }
  selectProduct(product){
    this.newProductUpdate = product;
  }

  fileChangeEvent(fileInput: any) {
    this.filesToUpload = <Array<File>>fileInput.target.files;

    //this.product.photo = fileInput.target.files[0]['name'];
  }
  addProduct(){
    console.log(this.newProduct.categoryId)

    const formData: any = new FormData();
    const files: Array<File> = this.filesToUpload;
    

    for(let i =0; i < files.length; i++){
        formData.append("picturesForm", files[i]);
    }
  

    formData.append("name",this.newProduct.name);
    formData.append("description",this.newProduct.description);
    formData.append("price",this.newProduct.price);
    formData.append("categoryId",this.newProduct.categoryId);

    console.log('form data variable :   '+ formData.toString());

    var response = this.productService.create(formData);

    response.subscribe(x => {
        this.getProducts();
    },error=>{
      console.log(error.message)
      alert('algum campo não foi preenchido');
    })

  }

  updateProduct(){
    console.log(this.newProductUpdate.categoryId)

    const formData: any = new FormData();
    const files: Array<File> = this.filesToUpload;
    

    for(let i =0; i < files.length; i++){
        formData.append("picturesForm", files[i]);
    }
  

    formData.append("name",this.newProductUpdate.name);
    formData.append("description",this.newProductUpdate.description);
    formData.append("price",this.newProductUpdate.price);
    formData.append("categoryId",this.newProductUpdate.categoryId);

    console.log('form data variable :   '+ formData.toString());

    var response = this.productService.update(this.newProductUpdate.id,formData);

    response.subscribe(x => {
      

    },error=>{
      console.log(error.message)
    })

  }

  activeImage(i){
    if(i === 0){
      return 'carousel-item active'
    }else{
      return 'carousel-item'
    }
  }

  carouselName(name){
    return "Carousel"+name;
  }

}
