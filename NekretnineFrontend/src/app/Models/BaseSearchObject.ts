export class BaseSearchObject{
  public Page : number;
  public PageSize : number;
  public TotalCount : number;
  public TotalPages : number;
  public HasPrevious : boolean;
  public HasNext : boolean;

  constructor(baseSearchObject? : BaseSearchObject,page?: number, pageSize?: number,totalCount?: number, totalPages?: number, HasPrevious ?: boolean, HasNext ?:boolean)
  {
    if(baseSearchObject != null) {
      this.Page = baseSearchObject.Page;
      this.PageSize = baseSearchObject.PageSize;
      this.TotalPages = baseSearchObject.TotalPages;
      this.TotalCount = baseSearchObject.TotalCount;
      this.HasNext = baseSearchObject.HasNext;
      this.HasPrevious = baseSearchObject.HasPrevious;
    }
    else{
      this.Page = page;
      this.PageSize = pageSize;
      this.TotalCount = totalCount;
      this.TotalPages = totalPages
      this.HasNext = HasNext;
      this.HasPrevious = HasPrevious;
    }
  }

}
