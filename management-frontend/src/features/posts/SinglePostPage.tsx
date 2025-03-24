import { Link, useParams } from "react-router-dom"

export const SinglePostPage = () => {
  const { postId } = useParams();

  // if(!post) {
  //   return (
  //     <section>
  //       <h2>Post not found!</h2>
  //     </section>
  //   );
  // }

  return (
    <section>
      <article className="post">
        {/* <h2>{post.title}</h2>
        <p className="post-contet">{post.content}</p>
        <Link to={`/editPost/${post.id}`} className="button">Edit Post</Link>
         */}
      </article>
    </section>
  )
}

