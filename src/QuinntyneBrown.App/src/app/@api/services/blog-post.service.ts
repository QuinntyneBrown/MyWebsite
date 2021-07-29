import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BlogPost } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { baseUrl, EntityPage, IPagableService } from '@core';

@Injectable({
  providedIn: 'root'
})
export class BlogPostService implements IPagableService<BlogPost> {

  uniqueIdentifierName: string = "blogPostId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<BlogPost>> {
    return this._client.get<EntityPage<BlogPost>>(`${this._baseUrl}api/blogPost/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<BlogPost[]> {
    return this._client.get<{ blogPosts: BlogPost[] }>(`${this._baseUrl}api/blogPost`)
      .pipe(
        map(x => x.blogPosts)
      );
  }

  public getById(options: { blogPostId: string }): Observable<BlogPost> {
    return this._client.get<{ blogPost: BlogPost }>(`${this._baseUrl}api/blogPost/${options.blogPostId}`)
      .pipe(
        map(x => x.blogPost)
      );
  }

  public remove(options: { blogPost: BlogPost }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/blogPost/${options.blogPost.blogPostId}`);
  }

  public create(options: { blogPost: BlogPost }): Observable<{ blogPost: BlogPost }> {
    return this._client.post<{ blogPost: BlogPost }>(`${this._baseUrl}api/blogPost`, { blogPost: options.blogPost });
  }
  
  public update(options: { blogPost: BlogPost }): Observable<{ blogPost: BlogPost }> {
    return this._client.put<{ blogPost: BlogPost }>(`${this._baseUrl}api/blogPost`, { blogPost: options.blogPost });
  }
}
